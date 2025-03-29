using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class FavoritesView : BaseContentPage
{
	public FavoritesView(FavoritesViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}