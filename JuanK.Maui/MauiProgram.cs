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
            builder.Services.AddSingleton<HttpClient>();

            // Registrar servicios
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<ApiService>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<TiendasViewModel>();

            // Registrar Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<TiendasPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
