using CommunityToolkit.Mvvm.ComponentModel;
using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Maui.ViewModels.Bases;

public abstract class ViewModelBase(IMessageService messageService) : ObservableObject
{
    protected readonly IMessageService MessageService = messageService;

    public Action<bool>? OnRequestVisibilityChange;
    protected void RequestVisibilityChange(bool visible)
    {
        this.OnRequestVisibilityChange?.Invoke(visible);
    }

    // INavigationServiceにして、MessageServiceと同じように扱う
    protected Task NavigateToRootAsync(string route, Dictionary<string, object>? parameter = null)
    {
        if (parameter is null)
        {
            return Shell.Current.GoToAsync($"//{route}");
        }

        return Shell.Current.GoToAsync($"//{route}", parameter);
    }

    // INavigationServiceにして、MessageServiceと同じように扱う
    protected Task NavigateToAsync(string route, Dictionary<string, object>? parameter = null)
    {
        if(parameter is null)
        {
            return Shell.Current.GoToAsync(route);
        }

        return Shell.Current.GoToAsync(route, parameter);
    }
}