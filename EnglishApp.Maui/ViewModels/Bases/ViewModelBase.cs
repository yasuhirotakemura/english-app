using CommunityToolkit.Mvvm.ComponentModel;
using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Maui.ViewModels.Bases;

public abstract class ViewModelBase(IMessageService messageService) : ObservableObject
{
    protected readonly IMessageService MessageService = messageService;

    protected Task NavigateToRootAsync(string route, Dictionary<string, object> parameter)
    {
        return Shell.Current.GoToAsync($"//{route}", parameter);
    }


    protected Task NavigateToAsync(string route, Dictionary<string, object> parameter)
    {
        return Shell.Current.GoToAsync(route, parameter);
    }
}