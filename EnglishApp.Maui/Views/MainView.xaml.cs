using EnglishApp.Domain.Entities;
using EnglishApp.Maui.ViewModels;
using System.Diagnostics;

namespace EnglishApp.Maui.Views;

public partial class MainView : ContentPage
{
    private INavigation _navigation;
    private readonly MainViewModel _mainViewModel;

    public MainView()
    {
        this.InitializeComponent();

        this._navigation = this.Navigation;

        this._mainViewModel = new();

        this.BindingContext = this._mainViewModel;
    }

    public void OnQuestionItemTapped(object sender, ItemTappedEventArgs e)
    {
        if(e.Item == null ||
           e.Item is not EnglishTextEntity englishTextEntity)
        {
            return;
        }

        Debug.WriteLine(englishTextEntity.Content);
    }
}
