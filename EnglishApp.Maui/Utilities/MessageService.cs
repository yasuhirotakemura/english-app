using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Maui.Utilities;

public sealed class MessageService : IMessageService
{
    public Task Show(string title, string message, string cancel = "はい")
    {
        return Shell.Current.CurrentPage.DisplayAlert(title, message, cancel);
    }

    public Task<bool> ShowConfirm(string title, string message, string accept = "はい", string cancel = "いいえ")
    {
        return Shell.Current.CurrentPage.DisplayAlert(title, message, accept, cancel);
    }
}
