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

        LoadQuestionsFromBackend();

        this.Loaded += async (s, e) =>
        {
            DisplayQuestion();
            await Task.Delay(300); // wait for layout measure
            AnimateProgress(0.0);
        };
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
            MainGrid.IsVisible = false;
            QuestionGrid.IsVisible = true;
            WelcomeContinueButton.IsVisible = false;
            QuestionContinueButton.IsVisible = true;
            //await Navigation.PushAsync(new BasicQuestions());
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
    private void LoadQuestionsFromBackend()
    {
        // Example data — replace later with backend API
        questions = new List<QuestionModel>
        {
            new QuestionModel { Text = "What would you like to learn?",
                Options = new List<OptionModel> {
                    new OptionModel { Text = "Arabic", IsCorrect = true ,Image = "learn_quran.png", }
                } },
            new QuestionModel { Text = "How did you hear about Quran Application?",
                Options = new List<OptionModel> {
                    new OptionModel { Text = "News/article/blog", IsCorrect = true },
                    new OptionModel { Text = "TikTok" },
                    new OptionModel { Text = "Google Search" },
                    new OptionModel { Text = "Friend/Family" },
                    new OptionModel { Text = "Facebook/Istagram" },
                    new OptionModel { Text = "App store" },
                    new OptionModel { Text = "TV" },
                    new OptionModel { Text = "YouTube" },
                    new OptionModel { Text = "Other" }
                } },
            new QuestionModel
            {
                Text = "How much Quran do you know?",
                Options = new List<OptionModel>
                {
                    new OptionModel { Text = "I'm new to learning the Quran", IsCorrect = true },
                    new OptionModel { Text = "I can read a few short Surahs", IsCorrect = true },
                    new OptionModel { Text = "I can recite basic Surahs with Tajweed", IsCorrect = true },
                    new OptionModel { Text = "I can read and understand some meanings", IsCorrect = true },
                    new OptionModel { Text = "I can recite fluently and reflect on meanings", IsCorrect = true }
                }
            },
            new QuestionModel
            {
                Text = "Why are you learning the Quran?",
                Options = new List<OptionModel>
                {
                    new OptionModel { Text = "To understand the words of Allah", IsCorrect = true },
                    new OptionModel { Text = "To improve my recitation and Tajweed", IsCorrect = true },
                    new OptionModel { Text = "To strengthen my connection with Islam", IsCorrect = true },
                    new OptionModel { Text = "To memorize and act upon it in daily life", IsCorrect = true }
                }
            },

            new QuestionModel { Text = "Let's set up a learning routine"},

            new QuestionModel { Text = "Whats your daily learning goal?",
                Options = new List<OptionModel> {
                    new OptionModel { Text = "3 min / day", IsCorrect = true },
                    new OptionModel { Text = "10 min/ day" },
                    new OptionModel { Text = "15 min / day" },
                    new OptionModel { Text = "30 min / day" }

                } },
            new QuestionModel { Text = "That's 25 wordsin your first week"},

            new QuestionModel { Text = "I'll cheer you on from your home screen!"},

          
            new QuestionModel { Text = "Here's what you can achve in 3 months!", },
            
            new QuestionModel { Text = "Now let's find the best place to start!", },

        };
    }
    private async void DisplayQuestion()
    {
        if (currentIndex >= questions.Count)
        {
            //QuestionLabel.Text = "🎉 You finished all questions!";
            await Navigation.PushAsync(new LevelSelection());
            OptionsList.ItemsSource = null;
            QuestionContinueButton.IsEnabled = false;
            AnimateProgress(1);
            return;
        }

        var question = questions[currentIndex];

        // Show question text
        QuestionLabel.Text = question.Text;
        await ShowTypewriterTextAsync(QuestionLabel, question.Text, 30);

        // ✅ Handle questions without options
        if (question.Options == null || question.Options.Count == 0)
        {
            OptionsList.ItemsSource = null;

            // Allow user to continue manually
            QuestionContinueButton.IsEnabled = true;
            QuestionContinueButton.BackgroundColor = Color.FromArgb("#58CC02");

            // Update progress bar
            double progress = (double)currentIndex / questions.Count;
            AnimateProgress(progress);
            return;
        }

        // ✅ If question has options
        foreach (var opt in question.Options)
            opt.BackgroundColor = Colors.White;

        OptionsList.ItemsSource = new ObservableCollection<OptionModel>(question.Options);

        // Disable Continue until an option is selected
        QuestionContinueButton.IsEnabled = false;
        QuestionContinueButton.BackgroundColor = Color.FromArgb("#E5E5E5");

        double optionProgress = (double)currentIndex / questions.Count;
        AnimateProgress(optionProgress);
    }

    private void OptionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var selected = e.CurrentSelection.FirstOrDefault() as OptionModel;
        if (selected == null)
            return;

        // Reset all selections
        foreach (var option in (OptionsList.ItemsSource as IEnumerable<OptionModel>))
            option.IsSelected = false;

        // Mark current one as selected
        selected.IsSelected = true;

        // ✅ Save selection so we can use it in ContinueButton_Clicked
        selectedOption = selected;

        // Optional: enable Continue button
        QuestionContinueButton.IsEnabled = true;
        QuestionContinueButton.BackgroundColor = Color.FromArgb("#58CC02");
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
        DisplayQuestion();
    }
    private async void AnimateProgress(double targetProgress)
    {
        // Clamp between 0 and 1
        targetProgress = Math.Clamp(targetProgress, 0.0, 1.0);

        // Wait until layout measured
        while (ProgressBarContainer.Width <= 0)
            await Task.Delay(50);

        // Calculate target width
        double totalWidth = ProgressBarContainer.Width;
        double targetWidth = targetProgress * totalWidth;

        // Cancel old animation (if any)
        ProgressFill.AbortAnimation("ProgressAnim");

        // Animate width
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var animation = new Animation(v =>
            {
                ProgressFill.WidthRequest = v;
                ProgressFill.InvalidateMeasure(); // refresh layout
            },
            ProgressFill.WidthRequest,
            targetWidth,
            Easing.CubicInOut);

            animation.Commit(this, "ProgressAnim", 16, 800); // 800ms duration
        });
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