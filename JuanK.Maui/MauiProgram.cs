using JuanK.Maui.Services;
using JuanK.Maui.ViewModels;
using JuanK.Maui.Views;
using Microsoft.Extensions.Logging;

namespace JuanK.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar HttpClient
            // Registrar HttpClient con handler específico para Android
            // Registrar HttpClient con configuración específica para Android
            builder.Services.AddSingleton<HttpClient>(sp =>
            {
                var handler = new HttpClientHandler();

                var httpClient = new HttpClient(handler)
                {
                    // Timeout muy generoso para conexiones lentas
                    Timeout = TimeSpan.FromSeconds(120) // 2 minutos
                };

                httpClient.BaseAddress = new Uri("http://147.185.238.132:8080/api/");

                return httpClient;
            });

            // Registrar servicios
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<ApiService>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<TiendasViewModel>();

            // Registrar Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<TiendasPage>();

            // Agrega esto para debuggear la inicialización
#if DEBUG
            builder.Logging.AddDebug();
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif

            return builder.Build();
        }
    }
}
