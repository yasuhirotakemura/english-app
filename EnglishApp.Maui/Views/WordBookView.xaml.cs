using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class WordBookView : BaseContentPage
{
	public WordBookView(WordBookViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}