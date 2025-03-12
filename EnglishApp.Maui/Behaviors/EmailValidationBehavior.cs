using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.Logics;

namespace EnglishApp.Maui.Behaviors;

public class EmailValidationBehavior() : Behavior<Entry>
{

    public static readonly BindableProperty MessageServiceProperty =
    BindableProperty.Create(nameof(MessageService), typeof(IMessageService), typeof(EmailValidationBehavior));

    public IMessageService MessageService
    {
        get => (IMessageService)this.GetValue(MessageServiceProperty);
        set => this.SetValue(MessageServiceProperty, value);
    }

    protected override void OnAttachedTo(Entry entry)
    {
        base.OnAttachedTo(entry);
        entry.Unfocused += this.OnEntryUnfocused;
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        base.OnDetachingFrom(entry);
        entry.Unfocused -= this.OnEntryUnfocused;
    }

    private async void OnEntryUnfocused(object? sender, FocusEventArgs e)
    {
        if (sender is not Entry entry)
        {
            return;
        }

        if (!EmailAnalysis.IsValid(entry.Text))
        {
            await this.MessageService.Show("エラー", "有効なメールアドレスを入力してください。");
        }
    }
}