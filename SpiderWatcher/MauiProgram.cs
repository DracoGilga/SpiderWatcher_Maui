using Microsoft.Extensions.Logging;
using SpiderWatcher.Conexion;
using SpiderWatcher.Services;
using Microsoft.Maui.Hosting;

namespace SpiderWatcher
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
                });

            // Agregar Blazor WebView
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Configuración específica del proyecto Blazor WebAssembly
            var grpcBaseDeAddress = "https://grcpsw.azurewebsites.net";
            var blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=spiderwatcherbs;AccountKey=fi8pH/Jt65gddZqKXB+SAXf0F2hGAtqksmRH7j6jBVqFhzqTKGu3tPT2TV0oD0edMo8HlbYqWSJ9+ASt/3odtQ==;EndpointSuffix=core.windows.net";
            var imageContainerName = "imagecontent";
            var videoContainerName = "videocontent";

            builder.Services.AddScoped(sp => new AzureBlobService(blobStorageConnectionString, imageContainerName));
            builder.Services.AddScoped(sp => new AzureVideoService(blobStorageConnectionString, videoContainerName));

            var apiBaseDeAddress = "https://apigatewaysw.azurewebsites.net";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseDeAddress) });

            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<NavigationService>();

            return builder.Build();
        }
    }
}
