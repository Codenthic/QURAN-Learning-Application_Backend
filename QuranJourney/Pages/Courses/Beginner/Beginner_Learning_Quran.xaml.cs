namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Learning_Quran : ContentPage
{
    private int currentQuestionIndex = 0;
    private string selectedAnswer = string.Empty;
    private bool isAnswerChecked = false;

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
    }
    
    private void Option_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        selectedAnswer = btn.Text;

        // Reset all buttons
        foreach (var child in OptionsGrid.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = Colors.White;
                b.TextColor = Colors.Black;
            }
        }

        // Highlight selected
        btn.BackgroundColor = Color.FromArgb("#1CB0F6");
        btn.TextColor = Colors.White;

        CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
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