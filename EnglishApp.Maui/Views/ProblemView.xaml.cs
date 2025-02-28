using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class ProblemView : ContentPage
{
    private readonly ProblemViewModel _problemViewModel;
	public ProblemView()
	{
		this.InitializeComponent();

        this._problemViewModel = new();

        this.BindingContext = this._problemViewModel;
	}
}