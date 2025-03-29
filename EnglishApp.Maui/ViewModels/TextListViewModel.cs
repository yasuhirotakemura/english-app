using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class TextListViewModel : ViewModelBase
{
    public TextListViewModel(IMessageService messageService) : base(messageService) { }
}
