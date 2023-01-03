using BlazorContact.Maui.Services;
using BlazorContact.Maui.Interfaces;
using Microsoft.AspNetCore.Components.WebView.Maui;
using CurrieTechnologies.Razor.SweetAlert2;

namespace BlazorContact.Maui {
    public static class MauiProgram {
        private static readonly string backendURL = @"https://backend-saeta.fly.dev/";
        //private static readonly string backendURL = @"https://d3b0-187-86-165-71.sa.ngrok.io/";
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendURL) });
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddSingleton<IAuthService, AuthService>();
			builder.Services.AddSweetAlert2();
			return builder.Build();
        }
    }
}