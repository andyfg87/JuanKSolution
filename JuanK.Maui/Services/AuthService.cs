using JuanK.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JuanK.Maui.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string AuthTokenKey = "auth_token";
        private const string UserDataKey = "user_data";

        public AuthService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://tu-api.com/api/"); // Cambiar por tu URL
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<bool> LoginAsync(string correo, string clave)
        {
            try
            {
                var loginRequest = new
                {
                    Correo = correo,
                    Clave = clave
                };

                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent, _jsonOptions);

                    // Guardar token y datos de usuario
                    await SecureStorage.SetAsync(AuthTokenKey, authResponse.Token);
                    await SecureStorage.SetAsync(UserDataKey, JsonSerializer.Serialize(authResponse.Usuario));

                    // Configurar el token en las requests futuras
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResponse.Token);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegisterAsync(UsuarioInputVM usuario)
        {
            try
            {
                var json = JsonSerializer.Serialize(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("auth/register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en registro: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await SecureStorage.GetAsync(AuthTokenKey);
            return !string.IsNullOrEmpty(token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(AuthTokenKey);
        }

        public async Task<UsuarioDisplayVM> GetUserDataAsync()
        {
            try
            {
                var userJson = await SecureStorage.GetAsync(UserDataKey);
                if (!string.IsNullOrEmpty(userJson))
                {
                    return JsonSerializer.Deserialize<UsuarioDisplayVM>(userJson, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo datos de usuario: {ex.Message}");
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            // Eliminar datos de autenticación
            SecureStorage.Remove(AuthTokenKey);
            SecureStorage.Remove(UserDataKey);

            // Remover header de autorización
            _httpClient.DefaultRequestHeaders.Authorization = null;

            await Shell.Current.GoToAsync("//login");
        }

        public void ConfigureHttpClient()
        {
            // Configurar el token en el HttpClient si existe
            var token = GetTokenAsync().GetAwaiter().GetResult();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
