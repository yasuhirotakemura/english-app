using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class SettingsView : BaseContentPage
{
	public SettingsView(SettingsViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}