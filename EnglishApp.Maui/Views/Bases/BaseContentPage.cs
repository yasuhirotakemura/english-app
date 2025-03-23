namespace EnglishApp.Maui.Views.Bases;

public class BaseContentPage : ContentPage
{
	public BaseContentPage()
	{

	}

    protected void HideBackButton() => Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = false, IsVisible = false });

    protected void HideNavigationBar() => Shell.SetNavBarIsVisible(this, false);
}