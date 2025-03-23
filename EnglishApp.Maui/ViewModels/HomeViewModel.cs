using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class HomeViewModel : ViewModelBase
{
    public HomeViewModel(IMessageService messageService) : base(messageService)
    {
    }
}