using EnglishApp.Maui.Routes;
using EnglishApp.Maui.Views;

namespace EnglishApp.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        this.InitializeComponent();

        Routing.RegisterRoute(AppShellRoute.WelcomeView, typeof(WelcomeView));
        Routing.RegisterRoute(AppShellRoute.SignUpView, typeof(SignUpView));
        Routing.RegisterRoute(AppShellRoute.UserProfileSetupView, typeof(UserProfileSetupView));
        Routing.RegisterRoute(AppShellRoute.SignInView, typeof(SignInView));
        Routing.RegisterRoute(AppShellRoute.HomeView, typeof(HomeView));
        Routing.RegisterRoute(AppShellRoute.TextListView, typeof(TextListView));
        Routing.RegisterRoute(AppShellRoute.FavoritesView, typeof(FavoritesView));
        Routing.RegisterRoute(AppShellRoute.WordBookView, typeof(WordBookView));
        Routing.RegisterRoute(AppShellRoute.SettingsView, typeof(SettingsView));
        Routing.RegisterRoute(AppShellRoute.UserProfileView, typeof(UserProfileView));
    }
}
