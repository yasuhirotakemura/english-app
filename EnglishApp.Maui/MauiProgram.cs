using CommunityToolkit.Maui;
using EnglishApp.Application.Interfaces;
using EnglishApp.Application.Services;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Utilities;
using EnglishApp.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace EnglishApp.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterViewModels()
            .RegisterServices()
            .RegisterApiServices()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<WelcomeViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<SignUpViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddTransient<ProblemViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IMessageService, MessageService>();

        return builder;
    }

    public static MauiAppBuilder RegisterApiServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<HttpClient>();

        builder.Services.AddSingleton<IEnglishTextApiService, EnglishTextApiService>();
        builder.Services.AddSingleton<IChoiceQuestionApiService, ChoiceQuestionApiService>();

        return builder;
    }
}