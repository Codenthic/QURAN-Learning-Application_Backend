using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuranJourney.Pages.Onboarding;

public partial class WelcomeScreen : ContentPage
{
    private int currentIndex = 0;
    private List<QuestionModel> questions;
    private OptionModel selectedOption;
    private bool isFirstClick = true;
    public WelcomeScreen()
	{
		InitializeComponent();
    }
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        if (isFirstClick)
        {
            // Fade out GIF before change
            await GifWebView.FadeTo(0, 400, Easing.CubicIn);

            // Change GIF
            string newGifHtml = @"
<html>
    <body style='margin:0; padding:0; display:flex; justify-content:flex-start; align-items:center; background: transparent; overflow:hidden; height:100%; width:100%;'>
        <img src='giphy2.gif' style='width:100%; height:100%; background: transparent; margin-left:20px; display:block;' />
    </body>
</html>";
            GifWebView.Source = new HtmlWebViewSource { Html = newGifHtml };

            // Fade GIF in again
            await GifWebView.FadeTo(1, 400, Easing.CubicOut);

            // Typewriter text animation
            string newText = "Just 6 quick Question before we start tour first lesson!";
            var label = new Label();
            label.FormattedText = new FormattedString
            {
                Spans =
                  {
                      new Span { Text = "Just " },
                      new Span { Text = "6 quick Question", FontAttributes = FontAttributes.Bold },
                      new Span { Text = " before we start your first lesson!" }
                  }
            };

            await ShowTypewriterFormattedAsync(SpeechLabel, label.FormattedText, 40);

            (sender as Button).Text = "CONTINUE";
            isFirstClick = false;
        }
        else
        {
            // Example: navigate next
            await Navigation.PushAsync(new BasicQuestions());
        }
    }
    private async Task ShowTypewriterFormattedAsync(Label label, FormattedString formattedString, int delay)
    {
        label.FormattedText = new FormattedString();

        foreach (var span in formattedString.Spans)
        {
            var newSpan = new Span
            {
                FontAttributes = span.FontAttributes,
                TextColor = span.TextColor,
                FontSize = span.FontSize
            };

            label.FormattedText.Spans.Add(newSpan);

            foreach (char c in span.Text)
            {
                newSpan.Text += c;
                await Task.Delay(delay);
            }
        }
    }
    private async void ContinueButton_Clicked(object sender, EventArgs e)
    {
        if (selectedOption == null) return;

        // Optional visual feedback (green/red flash)
        if (selectedOption.IsCorrect)
            selectedOption.BackgroundColor = Colors.LightGreen;
        else
            selectedOption.BackgroundColor = Colors.LightPink;

        // Small delay so user can see the color feedback
        await Task.Delay(600);

        // Move to next question automatically
        currentIndex++;
    }
    private void BackIcon_Tapped(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(".."); // or Navigation.PopAsync();
    }
    private void Back_Tapped(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(".."); // or Navigation.PopAsync();
    }
    private async Task ShowTypewriterTextAsync(Label label, string text, int delay = 40)
    {
        label.Text = "";
        foreach (char c in text)
        {
            label.Text += c;
            await Task.Delay(delay);
        }
    }

}
public class QuestionModel
{
    public string Text { get; set; }
    public List<OptionModel> Options { get; set; }
}


public class OptionModel : INotifyPropertyChanged
{
    private bool isSelected;

    public string Text { get; set; }
    public string Flag { get; set; }
    public bool IsCorrect { get; set; }
    public string Image { get; set; }
    public Color BackgroundColor { get; set; } = Colors.White;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected != value)
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}