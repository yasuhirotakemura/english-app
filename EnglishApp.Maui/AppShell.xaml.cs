using EnglishApp.Maui.Views;

namespace EnglishApp.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        this.InitializeComponent();

        Routing.RegisterRoute(nameof(WelcomeView), typeof(WelcomeView));
        Routing.RegisterRoute(nameof(SignInView), typeof(SignInView));
        Routing.RegisterRoute(nameof(SignUpView), typeof(SignUpView));
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        Routing.RegisterRoute(nameof(UserProfileSetupView), typeof(UserProfileSetupView));
    }
}
