using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(IMessageService messageService) : base(messageService) { }
}
