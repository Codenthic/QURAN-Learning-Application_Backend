using QuranJourney.Models;

namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Learning_Quran : ContentPage
{
    #region =============================== Fields / Variables =======================================
    private int currentQuestionIndex = 0;          // Track current question
    private string selectedAnswer = string.Empty;  // Track selected answer
    private bool isAnswerChecked = false;          // Track if answer checked (currently unused)
    private int currentActivityIndex = 0;          // Track activity type (0=SelectWord,1=WhatYouHear,2=WhatSound)
    private List<LetterQuizItem> shuffledQuestions; // Shuffled list of questions
    #endregion

    #region =============================== Constructor =============================================
    public Beginner_Learning_Quran()
    {
        InitializeComponent();

        // Load category and shuffle questions
        var category = SpecialLetterRepository.GetCategoryById(1);
        shuffledQuestions = category.QuizItems.OrderBy(x => Guid.NewGuid()).ToList();

        // Set CheckButton click event
        CheckButton.Clicked += CheckButton_Clicked;

        // Load first activity
        ShowCurrentActivity();

        // Initialize progress bar
        AnimateProgress(0.0);
    }
    #endregion

    #region =============================== Activity Management ======================================
    private void ShowCurrentActivity()
    {
        // 1️⃣ Hide all headers & grids
        Select_Word_Header.IsVisible = false;
        Select_Word_ContentGrid.IsVisible = false;
        What_You_Hear_Header.IsVisible = false;
        What_You_Hear_ContentGrid.IsVisible = false;
        What_Sound_Header.IsVisible = false;
        What_Sound_ContentGrid.IsVisible = false;

        // 2️⃣ Reset all option buttons
        ResetAllOptionButtons();

        // 3️⃣ Show current activity
        switch (currentActivityIndex)
        {
            case 0:
                Select_Word_Activity(shuffledQuestions[currentQuestionIndex]);
                Select_Word_Header.IsVisible = true;
                Select_Word_ContentGrid.IsVisible = true;
                break;

            case 1:
                What_You_Hear_Activity(shuffledQuestions[currentQuestionIndex]);
                What_You_Hear_Header.IsVisible = true;
                What_You_Hear_ContentGrid.IsVisible = true;
                break;

            case 2:
                What_Sound_Hear_LoadQuestion(shuffledQuestions[currentQuestionIndex]);
                What_Sound_Header.IsVisible = true;
                What_Sound_ContentGrid.IsVisible = true;
                break;
        }

        // Reset selection
        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");
    }
    #endregion

    #region =============================== Progress Bar Animation ===================================
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
    #endregion

    #region =============================== Select Word Activity ====================================
    // Load Select Word activity question & options
    public void Select_Word_Activity(LetterQuizItem quiz)
    {
        SelectWord_QuestionLabel.Text = quiz.EnglishLetter;

        SelectWord_Option1.Text = quiz.ArabicOptions[0];
        SelectWord_Option2.Text = quiz.ArabicOptions[1];
        SelectWord_Option3.Text = quiz.ArabicOptions[2];
    }

    // Handle button click for Select Word activity
    private void Select_Word_Option_Clicked(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        if (clickedButton == null) return;

        var buttons = new List<Button> { SelectWord_Option1, SelectWord_Option2, SelectWord_Option3 };

        foreach (var btn in buttons)
        {
            btn.BackgroundColor = Colors.White;
            btn.TextColor = Colors.Black;
        }

        clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
        clickedButton.TextColor = Colors.White;

        // Set selected answer
        selectedAnswer = clickedButton.Text;

        // Enable Check button
        CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
    }
    #endregion

    #region =============================== What You Hear Activity ==================================
    // Load What You Hear activity options
    public void What_You_Hear_Activity(LetterQuizItem quiz)
    {
        What_You_Hear_Option1.Text = quiz.ArabicOptions[0];
        What_You_Hear_Option2.Text = quiz.ArabicOptions[1];
        What_You_Hear_Option3.Text = quiz.ArabicOptions[2];
        What_You_Hear_Option4.Text = quiz.ArabicOptions[3];
    }

    // Handle What You Hear button click
    private void WhatYouHearOption_Clicked(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        if (clickedButton == null) return;

        var buttons = new List<Button> { What_You_Hear_Option1, What_You_Hear_Option2, What_You_Hear_Option3, What_You_Hear_Option4 };

        foreach (var btn in buttons)
        {
            btn.BackgroundColor = Colors.White;
            btn.BorderColor = Colors.Gray;
            btn.TextColor = Colors.Black;
        }

        clickedButton.BackgroundColor = Color.FromArgb("#1CB0F6");
        clickedButton.BorderColor = Color.FromArgb("#33AFF5");
        clickedButton.TextColor = Colors.White;

        // Set selected answer
        selectedAnswer = clickedButton.Text;

        // Enable Check button
        CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
    }
    #endregion

    #region =============================== What Sound Activity =====================================
    // Load dynamic buttons for What Sound activity
    private void What_Sound_Hear_LoadQuestion(LetterQuizItem quiz)
    {
        What_SoundArabicLetterLabel.Text = quiz.ArabicLetter;
        What_Sound_OptionsGrid.Children.Clear();

        int col = 0, row = 0;

        foreach (var opt in quiz.EnglishOptions)
        {
            var btn = new Button
            {
                Text = opt,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black,
                BorderColor = Color.FromArgb("#E0E0E0"),
                BorderWidth = 1,
                CornerRadius = 14,
                HeightRequest = 50,
                WidthRequest = 100,
                Margin = 5
            };
            btn.Clicked += What_Sound_Hear_Option_Clicked;

            What_Sound_OptionsGrid.Add(btn, col, row);

            col++;
            if (col == 3)
            {
                col = 0;
                row++;
            }
        }
    }

    // Handle What Sound button click
    private void What_Sound_Hear_Option_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        selectedAnswer = btn.Text;

        foreach (var child in What_Sound_OptionsGrid.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = Colors.White;
                b.TextColor = Colors.Black;
            }
        }

        btn.BackgroundColor = Color.FromArgb("#1CB0F6");
        btn.TextColor = Colors.White;

        CheckButton.BackgroundColor = Color.FromArgb("#58CC02");
    }
    #endregion

    #region =============================== Answer Validation ========================================
    // Universal validation method (checks Arabic or English automatically)
    private bool ValidateAnswer(string answer)
    {
        var currentQuiz = shuffledQuestions[currentQuestionIndex];

        if (Select_Word_ContentGrid.IsVisible || What_You_Hear_ContentGrid.IsVisible)
        {
            // Arabic answer check
            return currentQuiz.CorrectArabic == answer;
        }
        else if (What_Sound_ContentGrid.IsVisible)
        {
            // English answer check
            return currentQuiz.CorrectEnglish == answer;
        }

        return false;
    }

    // Handle CheckButton click
    private async void CheckButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedAnswer)) return;

        if (!isAnswerChecked)
        {
            bool isCorrect = ValidateAnswer(selectedAnswer);

            if (isCorrect)
            {
                CorrectBox.IsVisible = true;
                await CorrectBox.FadeTo(0, 800);
                CorrectBox.Opacity = 1;

            }
            else
            {
                WorngBox.IsVisible = true;
                await WorngBox.FadeTo(0, 800);
                WorngBox.Opacity = 1;
              
            }

            CheckButton.Text = "Continue";
            isAnswerChecked = true;
        }
        else
        {
            //await Task.Delay(500);
            //await CorrectBox.FadeTo(0, 800);
            //await WorngBox.FadeTo(0, 800);
            CorrectBox.IsVisible = false;
            WorngBox.IsVisible = false;
            UpdateProgress();
            LoadNextQuestion();
            CheckButton.Text = "Check";
            isAnswerChecked = false;
        }
    }


    #endregion

    #region =============================== Progress Update ==========================================
    private void UpdateProgress()
    {
        var category = SpecialLetterRepository.GetCategoryById(1);
        int totalQuestions = category.QuizItems.Count;

        int totalSteps = totalQuestions * 3;
        int currentStep = currentQuestionIndex * 3 + currentActivityIndex + 1;

        double progress = (double)currentStep / totalSteps;
        AnimateProgress(progress);
    }
    #endregion

    #region =============================== Next Question Logic =====================================
    private void LoadNextQuestion()
    {
        currentActivityIndex++;

        if (currentActivityIndex > 2)
        {
            currentActivityIndex = 0;
            currentQuestionIndex++;

            if (currentQuestionIndex >= shuffledQuestions.Count)
            {
                DisplayAlert("Done", "You finished all letters!", "OK");
                return;
            }
        }

        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");

        ShowCurrentActivity();
    }
    #endregion

    #region =============================== Reset Option Buttons ====================================
    private void ResetAllOptionButtons()
    {
        // Reset Select Word buttons
        var selectWordButtons = new List<Button> { SelectWord_Option1, SelectWord_Option2, SelectWord_Option3 };
        foreach (var btn in selectWordButtons)
        {
            btn.BackgroundColor = Colors.White;
            btn.TextColor = Colors.Black;
        }

        // Reset What You Hear buttons
        var whatYouHearButtons = new List<Button> { What_You_Hear_Option1, What_You_Hear_Option2, What_You_Hear_Option3, What_You_Hear_Option4 };
        foreach (var btn in whatYouHearButtons)
        {
            btn.BackgroundColor = Colors.White;
            btn.BorderColor = Colors.Gray;
            btn.TextColor = Colors.Black;
        }

        // Reset What Sound buttons (dynamic)
        foreach (var child in What_Sound_OptionsGrid.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = Colors.White;
                b.TextColor = Colors.Black;
            }
        }
    }
    #endregion
}
