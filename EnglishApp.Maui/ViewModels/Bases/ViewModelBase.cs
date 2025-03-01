using CommunityToolkit.Mvvm.ComponentModel;

namespace EnglishApp.Maui.ViewModels.Bases;

public abstract class ViewModelBase : ObservableObject
{
    public virtual Task NavigateToAsync(string route, object parameter = null)
    {
        return Shell.Current.GoToAsync(route, parameter != null ? new Dictionary<string, object> { { "parameter", parameter } } : null);
    }
}