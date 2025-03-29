using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class TextListView : BaseContentPage
{
	public TextListView(TextListViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}