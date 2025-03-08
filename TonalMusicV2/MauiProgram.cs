using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TonalMusicV2.PageModels;
using TonalMusicV2.Pages;
using TonalMusicV2.Rest;
using TonalMusicV2.Service;

namespace TonalMusicV2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageModel>();
            builder.Services.AddTransient<AlbumPage>();
            builder.Services.AddTransient<ArtistPage>();
            builder.Services.AddTransient<SongPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddScoped<SettingsPageModel>();
            builder.Services.AddSingleton<SongPageModel>();
            builder.Services.AddScoped<ArtistService>();
            builder.Services.AddScoped<ArtistPageModel>();
            builder.Services.AddScoped<AlbumService>();
            builder.Services.AddScoped<AlbumPageModel>();
            builder.Services.AddScoped<SongService>();
            builder.Services.AddScoped<RestClient>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
