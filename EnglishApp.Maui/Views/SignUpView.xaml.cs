using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class SignUpView : BaseContentPage
{
	public SignUpView(SignUpViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}