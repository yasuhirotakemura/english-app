using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class FavoritesViewModel: ViewModelBase
{
    public FavoritesViewModel(IMessageService messageService) : base(messageService) { }
}
