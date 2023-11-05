using AppControleFinanceiro.Data;
using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositorio;
using AppControleFinanceiro.View;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace AppControleFinanceiro
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
                }).Registrador_BD_Repositorio();
            
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
        public static MauiAppBuilder Registrador_BD_Repositorio(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<LiteDatabase>(
                opcoes =>
                {
                    return new LiteDatabase($"FileName={AppSettings.caminhoArquivoDB}Connection=Shared");
                }
                );
            app.Services.AddTransient<IRepositorioDeTransacao, RepositorioDeTransacao>();
            return app;
        }
        public static MauiAppBuilder RegistradorView(this MauiAppBuilder app)
        {
          
            app.Services.AddTransient<ListaDeTransacao>();
            app.Services.AddTransient<AddTransacao>();
            app.Services.AddTransient<EdicaoDeTransacao>();
            return app;
        }

    }
}