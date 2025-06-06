﻿using CommunityToolkit.Maui;
using EnglishApp.Application;
using EnglishApp.Application.ApiClients;
using EnglishApp.Application.Interfaces;
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
        MauiApp app = builder.Build();

        return builder.Build();
	}

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<WelcomeViewModel>();
        builder.Services.AddSingleton<SignInViewModel>();
        builder.Services.AddSingleton<SignUpViewModel>();
        builder.Services.AddSingleton<UserProfileSetupViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<TextListViewModel>();
        builder.Services.AddSingleton<FavoritesViewModel>();
        builder.Services.AddSingleton<WordBookViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<UserProfileViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IMessageService, MessageService>();
        builder.Services.AddTransient<INavigationService, NavigationService>();

        return builder;
    }

    public static MauiAppBuilder RegisterApiServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(sp =>
        {
            HttpClient client = new()
            {
#if DEBUG && ANDROID
                BaseAddress = new Uri("http://10.0.2.2:5249/api/")
#elif DEBUG
                BaseAddress = new Uri("http://localhost:5249/api/")
#else
                BaseAddress = new Uri("https://your-api-endpoint.com/api/")
#endif
            };

            return client;
        });
        builder.Services.AddSingleton<ApiRequestHandler>();

        builder.Services.AddSingleton<IUserAuthApiClient, UserAuthApiClient>();
        builder.Services.AddSingleton<IUserProfileApiClient, UserProfileApiClient>();

        return builder;
    }
}