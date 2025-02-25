using EnglishApp.Domain.Entities;
using EnglishApp.Maui.Services;
using System.Collections.Immutable;
using System.Diagnostics;

namespace EnglishApp.Maui;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        EnglishTextService service = new(new());

        ImmutableList<EnglishTextEntity>? testGet = await service.GetEnglishTextsAsync();

        Debug.WriteLine("HELLO");

        if(testGet is not null)
        {
            foreach (EnglishTextEntity entity in testGet)
            {
                Debug.WriteLine(entity.Content + "\n");
            }
        }
    }
}
