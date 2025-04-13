using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class WordBookViewModel : ViewModelBase
{
    public WordBookViewModel(IMessageService messageService,
                             INavigationService navigationService) : base(messageService,
                                                                          navigationService) { }
}
