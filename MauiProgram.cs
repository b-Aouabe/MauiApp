using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MauiApp1.DbConfig;
using MauiApp1.Views;
using MauiApp1.ViewModels;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("BarlowBold.otf", "BarlowBold");
                    fonts.AddFont("BarlowMedium.otf", "BarlowMedium");
                    fonts.AddFont("BarlowRegular.otf", "BarlowRegular");
                    fonts.AddFont("BarlowSemiBold.otf", "BarlowSemiBold");
                });

            builder.Services.AddSingleton<AddStudentPage>();
            builder.Services.AddSingleton<DefaultPage>();
            builder.Services.AddSingleton<UpdateAbsencePage>();


            builder.Services.AddSingleton<AddStudentVM>();
            builder.Services.AddSingleton<DefaultPageViewModel>();
            builder.Services.AddSingleton<UpdateAbsenceVM>();


            builder.Services.AddSingleton<LocalDbService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
