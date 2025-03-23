using EnglishApp.Maui.Views;

namespace EnglishApp.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        this.InitializeComponent();

        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(SignUpView), typeof(SignUpView));
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        Routing.RegisterRoute(nameof(ProblemView), typeof(ProblemView));
        Routing.RegisterRoute(nameof(UserProfileSetupView), typeof(UserProfileSetupView));
    }
}
