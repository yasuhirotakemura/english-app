using CommunityToolkit.Mvvm.ComponentModel;

namespace EnglishApp.Maui.ViewModels.Bases;

public abstract class ViewModelBase : ObservableObject
{
    public virtual Task NavigateToAsync(string route, Dictionary<string, object> parameter)
    {
        return Shell.Current.GoToAsync(route, parameter);
    }
}