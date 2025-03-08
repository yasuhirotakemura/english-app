using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class ProblemView : ContentPage
{
	public ProblemView(ProblemViewModel problemViewModel)
	{
		this.InitializeComponent();

        this.BindingContext = problemViewModel;
	}
}