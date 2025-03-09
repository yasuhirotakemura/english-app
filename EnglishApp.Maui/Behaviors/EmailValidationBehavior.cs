using EnglishApp.Domain.Logics;

namespace EnglishApp.Maui.Behaviors;

public class EmailValidationBehavior : Behavior<Entry>
{
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
        if(sender is not Entry entry)
        {
            return;
        }

        if(!EmailAnalysis.IsValidEmail(entry.Text) &&
            Shell.Current is Shell currentShell &&
            currentShell.CurrentPage is Page currentPage)
        {
            await currentPage.DisplayAlert("エラー", "無効なメールアドレスです。", "OK");
        }
    }
}