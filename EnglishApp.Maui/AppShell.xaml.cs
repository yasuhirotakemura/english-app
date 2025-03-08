using EnglishApp.Maui.Views;

namespace EnglishApp.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        this.InitializeComponent();

        Routing.RegisterRoute(nameof(ProblemView), typeof(ProblemView));
    }
}
