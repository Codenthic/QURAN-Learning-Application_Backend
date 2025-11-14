namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Learning_Quran : ContentPage
{
	public Beginner_Learning_Quran()
	{
		InitializeComponent();
        LoadQuestion();
        AnimateProgress(0.0);
    }
    private async void AnimateProgress(double targetProgress)
    {
        targetProgress = Math.Clamp(targetProgress, 0.0, 1.0);

        while (ProgressBarContainer.Width <= 0)
            await Task.Delay(50);

        double totalWidth = ProgressBarContainer.Width;
        double targetWidth = targetProgress * totalWidth;

        ProgressFill.AbortAnimation("ProgressAnim");

        MainThread.BeginInvokeOnMainThread(() =>
        {
            var animation = new Animation(v =>
            {
                ProgressFill.WidthRequest = v;
                ProgressFill.InvalidateMeasure();
            },
            ProgressFill.WidthRequest,
            targetWidth,
            Easing.CubicInOut);

            animation.Commit(this, "ProgressAnim", 16, 800);
        });
    }
    private void LoadQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            Navigation.PushAsync(new Beginner_Correct_Char());
            return;
        }

        var q = questions[currentQuestionIndex];
        QuestionLabel.Text = q.QuestionText;
        ArabicLetterLabel.Text = q.ArabicLetter;

        OptionsGrid.Children.Clear();
        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");

        int col = 0, row = 0;
        foreach (var opt in q.Options)
        {
            var btn = new Button
            {
                Text = opt,
                FontSize = 18,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black,
                BorderColor = Color.FromArgb("#E0E0E0"),
                BorderWidth = 1,
                CornerRadius = 14,
                HeightRequest = 50,
                WidthRequest = 100,
                Margin = new Thickness(5)
            };
            btn.Clicked += Option_Clicked;

            OptionsGrid.Add(btn, col, row);
            col++;
            if (col == 3)
            {
                col = 0;
                row++;
            }
        }

        ResultGifWebView.IsVisible = false;
        ResultGifWebView.Opacity = 0;
        ResultGifWebView.TranslationY = 200;
    }
    private readonly List<QuestionModel> questions = new()
        {
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),

            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
        };
}