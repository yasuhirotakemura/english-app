using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class SignInView : BaseContentPage
{
	public SignInView(SignInViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}