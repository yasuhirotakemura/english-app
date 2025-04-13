using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class HomeViewModel : ViewModelBase, IQueryAttributable
{
    public HomeViewModel(IMessageService messageService,
                         INavigationService navigationService) : base(messageService,
                                                                      navigationService)
    {
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }
}