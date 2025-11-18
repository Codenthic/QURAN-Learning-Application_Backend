using Microsoft.Maui;
using QuranJourney.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuranJourney.Pages.Onboarding;

public partial class BasicQuestions : ContentPage
{
    private int currentIndex = 0;
    private List<QuestionModel> questions;
    private BasicOptionModel selectedOption;
    private bool isFirstClick = true;

    public BasicQuestions()
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
    private void LoadQuestionsFromBackend()
    {
        // Example data — replace later with backend API
        questions = new List<QuestionModel>
        {
            new QuestionModel { Text = "What would you like to learn?",
                Options = new List<BasicOptionModel> {
                    new BasicOptionModel { Text = "Arabic", IsCorrect = true ,Image = "learn_quran.png", }
                } },
            new QuestionModel { Text = "How did you hear about Quran Application?",
                Options = new List<BasicOptionModel> {
                    new BasicOptionModel { Text = "News/article/blog", IsCorrect = true },
                    new BasicOptionModel { Text = "TikTok" },
                    new BasicOptionModel { Text = "Google Search" },
                    new BasicOptionModel { Text = "Friend/Family" },
                    new BasicOptionModel { Text = "Facebook/Istagram" },
                    new BasicOptionModel { Text = "App store" },
                    new BasicOptionModel { Text = "TV" },
                    new BasicOptionModel { Text = "YouTube" },
                    new BasicOptionModel { Text = "Other" }
                } },
            new QuestionModel
            {
                Text = "How much Quran do you know?",
                Options = new List<BasicOptionModel>
                {
                    new BasicOptionModel { Text = "I'm new to learning the Quran", IsCorrect = true },
                    new BasicOptionModel { Text = "I can read a few short Surahs", IsCorrect = true },
                    new BasicOptionModel { Text = "I can recite basic Surahs with Tajweed", IsCorrect = true },
                    new BasicOptionModel { Text = "I can read and understand some meanings", IsCorrect = true },
                    new BasicOptionModel { Text = "I can recite fluently and reflect on meanings", IsCorrect = true }
                }
            },
            new QuestionModel
            {
                Text = "Why are you learning the Quran?",
                Options = new List<BasicOptionModel>
                {
                    new BasicOptionModel { Text = "To understand the words of Allah", IsCorrect = true },
                    new BasicOptionModel { Text = "To improve my recitation and Tajweed", IsCorrect = true },
                    new BasicOptionModel { Text = "To strengthen my connection with Islam", IsCorrect = true },
                    new BasicOptionModel { Text = "To memorize and act upon it in daily life", IsCorrect = true }
                }
            },

            new QuestionModel { Text = "Let's set up a learning routine"},

            new QuestionModel { Text = "Whats your daily learning goal?",
                Options = new List<BasicOptionModel> {
                    new BasicOptionModel { Text = "3 min / day", IsCorrect = true },
                    new BasicOptionModel { Text = "10 min/ day" },
                    new BasicOptionModel { Text = "15 min / day" },
                    new BasicOptionModel { Text = "30 min / day" }

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

        OptionsList.ItemsSource = new ObservableCollection<BasicOptionModel>(question.Options);

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

        var selected = e.CurrentSelection.FirstOrDefault() as BasicOptionModel;
        if (selected == null)
            return;

        // Reset all selections
        foreach (var option in (OptionsList.ItemsSource as IEnumerable<BasicOptionModel>))
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