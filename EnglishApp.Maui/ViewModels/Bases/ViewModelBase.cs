using CommunityToolkit.Mvvm.ComponentModel;
using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Maui.ViewModels.Bases;

public abstract class ViewModelBase(IMessageService messageService, INavigationService navigationService) : ObservableObject
{
    protected readonly IMessageService MessageService = messageService;
    protected readonly INavigationService NavigationService = navigationService;

    public Action<bool>? OnRequestVisibilityChange;
    protected void RequestVisibilityChange(bool visible)
    {
        this.OnRequestVisibilityChange?.Invoke(visible);
    }
}