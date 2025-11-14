using QuranJourney.Models;

namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Learning_Quran : ContentPage
{
    private int currentQuestionIndex = 0;
    private string selectedAnswer = string.Empty;
    private bool isAnswerChecked = false;
    private int currentActivityIndex = 0;

    public Beginner_Learning_Quran()
	{
		InitializeComponent();
        var category = SpecialLetterRepository.GetCategoryById(1);
        // Set CheckButton click
        CheckButton.Clicked += CheckButton_Clicked;
        ShowCurrentActivity(category);
        AnimateProgress(0.0);
    }
    private void ShowCurrentActivity(LetterCategory category)
    {
        // 1️⃣ Hide all content grids and headers
        Select_Word_Header.IsVisible = false;
        Select_Word_ContentGrid.IsVisible = false;

        What_You_Hear_Header.IsVisible = false;
        What_You_Hear_ContentGrid.IsVisible = false;

        What_Sound_Header.IsVisible = false;
        What_Sound_ContentGrid.IsVisible = false;

        // 2️⃣ Reset all option buttons
        ResetAllOptionButtons();

        // 3️⃣ Show only the current activity
        switch (currentActivityIndex)
        {
            case 0:
                Select_Word_Activity(category);
                Select_Word_Header.IsVisible = true;
                Select_Word_ContentGrid.IsVisible = true;
                break;
            case 1:
                What_You_Hear_Activity(category);
                What_You_Hear_Header.IsVisible = true;
                What_You_Hear_ContentGrid.IsVisible = true;
                break;
            case 2:
                What_Sound_Hear_LoadQuestion(category);
                What_Sound_Header.IsVisible = true;
                What_Sound_ContentGrid.IsVisible = true;
                break;
        }

        // 4️⃣ Reset selection and CheckButton
        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");
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

    #region =============================== Select Word Activity =======================================

    public void Select_Word_Activity(LetterCategory letterCategory)
    {
        if(letterCategory != null)
        {
            Select_Word_Header.IsVisible = true;
            Select_Word_ContentGrid.IsVisible = true;


            var quiz = letterCategory.QuizItems[0];
            SelectWord_QuestionLabel.Text = quiz.EnglishLetter;

            SelectWord_Option1.Text = quiz.ArabicOptions[0];
            SelectWord_Option2.Text = quiz.ArabicOptions[1];
            SelectWord_Option3.Text = quiz.ArabicOptions[2];
        }
    }
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

    #region =============================== What_You_Hear_Activity =======================================
    public void What_You_Hear_Activity(LetterCategory letterCategory)
    {
        if (letterCategory != null)
        {
            What_You_Hear_Header.IsVisible = true;
            What_You_Hear_ContentGrid.IsVisible = true;


            var quiz = letterCategory.QuizItems[0];
            //Add Sound Mp3
            //SelectWord_QuestionLabel.Text = quiz.EnglishLetter;

            What_You_Hear_Option1.Text = quiz.ArabicOptions[0];
            What_You_Hear_Option2.Text = quiz.ArabicOptions[1];
            What_You_Hear_Option3.Text = quiz.ArabicOptions[2];
            What_You_Hear_Option4.Text = quiz.ArabicOptions[3];

        }
    }
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


    private void ResetButtons()
    {
        var buttons = new List<Button>
    {
        What_You_Hear_Option1,
        What_You_Hear_Option2,
        What_You_Hear_Option3,
        What_You_Hear_Option4
    };

        foreach (var btn in buttons)
        {
            btn.BackgroundColor = Microsoft.Maui.Graphics.Colors.White;
        }
    }
    #endregion

    #region =============================== What_You_Hear_Activity =======================================
    public void What_Sound_Hear_Activity(LetterCategory letterCategory)
    {
        if (letterCategory != null)
        {
            What_You_Hear_Header.IsVisible = true;
            What_You_Hear_ContentGrid.IsVisible = true;


            var quiz = letterCategory.QuizItems[0];

            What_SoundArabicLetterLabel.Text = quiz.EnglishLetter;

            What_You_Hear_Option1.Text = quiz.ArabicOptions[0];
            What_You_Hear_Option2.Text = quiz.ArabicOptions[1];
            What_You_Hear_Option3.Text = quiz.ArabicOptions[2];
            What_You_Hear_Option4.Text = quiz.ArabicOptions[3];

        }
    }

    private void What_Sound_Hear_LoadQuestion(LetterCategory letterCategory)
    {
        if (letterCategory == null)
        {
            Navigation.PushAsync(new Beginner_Correct_Char());
            return;
        }
        What_Sound_Header.IsVisible = true;
        What_Sound_ContentGrid.IsVisible = true;

        var quiz = letterCategory.QuizItems[0];
        What_SoundArabicLetterLabel.Text = quiz.ArabicLetter;

        What_Sound_OptionsGrid.Children.Clear();
        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");

        int col = 0, row = 0;
        foreach (var opt in quiz.EnglishOptions)
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

    private void What_Sound_Hear_Option_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        selectedAnswer = btn.Text;

        // Reset all buttons
        foreach (var child in What_Sound_OptionsGrid.Children)
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
    private void What_Sound_Option_Clicked(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        if (clickedButton == null) return;

        // List of all buttons
        var buttons = new List<Button>
         {
             What_You_Hear_Option1,
             What_You_Hear_Option2,
             What_You_Hear_Option3,
             What_You_Hear_Option4
         };

        // Reset all buttons to white
        foreach (var btn in buttons)
        {
            btn.BackgroundColor = Microsoft.Maui.Graphics.Colors.White;
            btn.BorderColor = Microsoft.Maui.Graphics.Colors.Gray;
            btn.TextColor = Microsoft.Maui.Graphics.Colors.Black;
        }

        clickedButton.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#1CB0F6");
        clickedButton.BorderColor = Microsoft.Maui.Graphics.Color.FromArgb("#33AFF5");
        clickedButton.TextColor = Microsoft.Maui.Graphics.Color.FromArgb("#FFFFFF");
    }
    #endregion

    private async void CheckButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedAnswer))
            return; // No answer selected

        bool isCorrect = false;

        // Determine which activity is currently active
        if (Select_Word_ContentGrid.IsVisible)
        {
            isCorrect = ValidateSelectWordAnswer(selectedAnswer);
        }
        else if (What_You_Hear_ContentGrid.IsVisible)
        {
            isCorrect = ValidateWhatYouHearAnswer(selectedAnswer);
        }
        else if (What_Sound_ContentGrid.IsVisible)
        {
            isCorrect = ValidateWhatSoundAnswer(selectedAnswer);
        }

        if (isCorrect)
        {
            CorrectBox.IsVisible = true;
            await Task.Delay(1000);
            CorrectBox.IsVisible = false;
        }
        else
        {
            WorngBox.Opacity = 1;
            WorngBox.IsVisible = true;
            await Task.Delay(500);
            await WorngBox.FadeTo(0, 800);
            WorngBox.Opacity = 1;
            WorngBox.IsVisible = false;
        }

        // Update progress bar
        UpdateProgress();

        // Load next question
        LoadNextQuestion();
    }
    private void UpdateProgress()
    {
        var category = SpecialLetterRepository.GetCategoryById(1);
        int totalQuestions = category.QuizItems.Count;

        // Total steps = number of questions * number of activities (3)
        int totalSteps = totalQuestions * 3;

        // Current step = currentQuestionIndex * 3 + currentActivityIndex + 1
        int currentStep = currentQuestionIndex * 3 + currentActivityIndex + 1;

        double progress = (double)currentStep / totalSteps;

        AnimateProgress(progress);
    }

    private bool ValidateSelectWordAnswer(string answer)
    {
        var quiz = SpecialLetterRepository.GetCategoryById(1).QuizItems[currentQuestionIndex];
        return quiz.ArabicOptions.Contains(answer); // Or compare with correct option index
    }
    private bool ValidateWhatYouHearAnswer(string answer)
    {
        var quiz = SpecialLetterRepository.GetCategoryById(1).QuizItems[currentQuestionIndex];
        return quiz.ArabicOptions.Contains(answer);
    }

    private bool ValidateWhatSoundAnswer(string answer)
    {
        var quiz = SpecialLetterRepository.GetCategoryById(1).QuizItems[currentQuestionIndex];
        return quiz.EnglishOptions.Contains(answer);
    }
    private void LoadNextQuestion()
    {
        var category = SpecialLetterRepository.GetCategoryById(1);

        // Cycle activity first
        currentActivityIndex++;
        if (currentActivityIndex > 2)
        {
            // All 3 activities done, move to next question
            currentActivityIndex = 0;
            currentQuestionIndex++;

            if (currentQuestionIndex >= category.QuizItems.Count)
            {
                // All questions finished
                DisplayAlert("Done", "You finished all letters!", "OK");
                return;
            }
        }

        selectedAnswer = string.Empty;
        CheckButton.BackgroundColor = Color.FromArgb("#E0E0E0");

        ShowCurrentActivity(category);
    }
    private void ResetAllOptionButtons()
    {
        // Select Word Buttons
        var selectWordButtons = new List<Button> { SelectWord_Option1, SelectWord_Option2, SelectWord_Option3 };
        foreach (var btn in selectWordButtons)
        {
            btn.BackgroundColor = Colors.White;
            btn.TextColor = Colors.Black;
        }

        // What You Hear Buttons
        var whatYouHearButtons = new List<Button> { What_You_Hear_Option1, What_You_Hear_Option2, What_You_Hear_Option3, What_You_Hear_Option4 };
        foreach (var btn in whatYouHearButtons)
        {
            btn.BackgroundColor = Colors.White;
            btn.BorderColor = Colors.Gray;
            btn.TextColor = Colors.Black;
        }

        // What Sound Buttons (dynamic buttons in Grid)
        foreach (var child in What_Sound_OptionsGrid.Children)
        {
            if (child is Button b)
            {
                b.BackgroundColor = Colors.White;
                b.TextColor = Colors.Black;
            }
        }
    }



}