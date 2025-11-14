using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuranJourney.Pages.Courses.Beginner
{
    public partial class Beginner_Learn_Quran : ContentPage
    {
        private int currentQuestionIndex = 0;
        private string selectedAnswer = string.Empty;
        private bool isAnswerChecked = false;

        private readonly List<QuestionModel> questions = new()
        {
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),

            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),
            new QuestionModel("ء", "What sound does this make?", "ʔ", new List<string> { "ʔ", "a", "e", "i" }),      
        };
        
        public Beginner_Learn_Quran()
        {
            InitializeComponent();
            LoadQuestion();
            AnimateProgress(0.0);
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

        private async void CheckButton_Clicked(object sender, EventArgs e)
        {
            // If answer already checked → Now Continue pressed
            if (isAnswerChecked)
            {
                isAnswerChecked = false;
                CheckButton.Text = "Check";
                currentQuestionIndex++;
                LoadQuestion();
                return;
            }

            if (string.IsNullOrEmpty(selectedAnswer))
            {
                await DisplayAlert("Select an answer", "Please select an option first.", "OK");
                return;
            }

            bool correct = selectedAnswer == questions[currentQuestionIndex].CorrectAnswer;

            // Reset colors
            foreach (var child in OptionsGrid.Children)
            {
                if (child is Button b)
                {
                    b.BackgroundColor = Colors.White;
                    b.TextColor = Colors.Black;
                }
            }

            // Mark selected
            foreach (var child in OptionsGrid.Children)
            {
                if (child is Button b && b.Text == selectedAnswer)
                {
                    b.BackgroundColor = correct ? Color.FromArgb("#58CC02") : Colors.Red;
                    b.TextColor = Colors.White;
                }
            }

            //// Show GIF
            //string gifName = correct ? "correctanswer.gif" : "wrong.gif";
            //ResultGifWebView.Source = new HtmlWebViewSource
            //{
            //    Html = $@"
            //     <html>
            //         <body style='margin:0; padding:0; display:flex; justify-content:center; align-items:center; 
            //                      background:transparent; width:100vw; height:100vh; overflow:hidden;'>
            //             <img src='{gifName}' 
            //                  style='width:100vw; height:auto; object-fit:contain;' />
            //         </body>
            //     </html>"
            //};
            //await Task.Delay(2000);
            ResultGifWebView.IsVisible = true;
            await Task.Delay(3000); // short delay
            ResultGifWebView.IsVisible = false;

            if (correct)
            {
                double progress = (double)(currentQuestionIndex + 1) / questions.Count;
                AnimateProgress(progress);
            }

            // 🔥 Now answer is checked — next click will be Continue
            CheckButton.Text = "Continue";
            isAnswerChecked = true;
        }



        private async void SpeakerButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var textToSpeak = ArabicLetterLabel.Text;
                await TextToSpeech.Default.SpeakAsync(textToSpeak);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Cannot play audio: {ex.Message}", "OK");
            }
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
    }
}

    public class QuestionModel
    {
        public string ArabicLetter { get; }
        public string QuestionText { get; }
        public string CorrectAnswer { get; }
        public List<string> Options { get; }

        public QuestionModel(string letter, string question, string correct, List<string> options)
        {
            ArabicLetter = letter;
            QuestionText = question;
            CorrectAnswer = correct;
            Options = options;
        }
    }

