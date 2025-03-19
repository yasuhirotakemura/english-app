namespace EnglishApp.Domain.Interfaces;

public interface IMessageService
{
    Task Show(string title, string message, string cancel = "はい");

    Task<bool> ShowConfirm(string title, string message, string accept = "はい", string cancel = "いいえ");
}