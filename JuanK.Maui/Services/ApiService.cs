using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JuanK.Maui.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            ConfigureHttpClient();
        }

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;           
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _httpClient.BaseAddress = new Uri("http://147.185.238.132:8080/api/");
            //ConfigureHttpClient();
        }

        private async void ConfigureHttpClient()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("http://147.185.238.132:8080/api/");

                // Configurar headers comunes
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "JuanK.Maui");

                var token = await _authService.GetTokenAsync();
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring HttpClient: {ex.Message}");
            }
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            int retryCount = 0;
            const int maxRetries = 3;

            while (retryCount < maxRetries)
            {
                try
                {
                    Debug.WriteLine($"🔗 Attempt {retryCount + 1}: Calling {endpoint}");

                    var token = await _authService.GetTokenAsync();
                    if (!string.IsNullOrEmpty(token))
                    {
                        _httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }

                    var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

                    Debug.WriteLine($"📥 Response: {response.StatusCode}");

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine($"✅ Successfully loaded {content.Length} characters");

                    return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
                {
                    retryCount++;
                    Debug.WriteLine($"⏰ Timeout on attempt {retryCount}, retrying...");

                    if (retryCount >= maxRetries)
                    {
                        Debug.WriteLine("❌ Max retries reached");
                        throw new TimeoutException("La conexión es demasiado lenta después de múltiples intentos");
                    }

                    // Esperar antes de reintentar (backoff exponencial)
                    await Task.Delay(TimeSpan.FromSeconds(2 * retryCount));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"❌ API Error: {ex.Message}");
                    throw;
                }
            }

            throw new TimeoutException("No se pudo completar la solicitud después de múltiples intentos");
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await _authService.LogoutAsync();
                }
                throw;
            }
        }

        public async Task<bool> PutAsync<TRequest>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await _authService.LogoutAsync();
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(endpoint);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await _authService.LogoutAsync();
                }
                throw;
            }
        }
    }
}
