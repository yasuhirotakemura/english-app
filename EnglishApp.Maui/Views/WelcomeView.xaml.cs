using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class WelcomeView : BaseContentPage
{
	public WelcomeView(WelcomeViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;

        this.HideNavigationBar();

        viewModel.OnRequestVisibilityChange += this.OnRequestVisibilityChange;

        Task.Run(viewModel.TryAutoLoginAsync);
    }
}