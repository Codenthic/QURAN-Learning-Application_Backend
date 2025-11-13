using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace QuranJourney.Pages.Courses.Beginner
{
    public partial class Beginner_Select_Word: ContentPage
    {
        private List<QuestionsModel> _questions;
        private int _currentIndex = 0;
        private int _score = 0;
        private bool _answered = false;

        public Beginner_Select_Word()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayQuestion();
            AnimateProgress(0.0);
        }

        private void LoadQuestions()
        {
            _questions = new List<QuestionsModel>
            {
                new QuestionsModel { Word = "Alif", Options = new []{"الف", "ب", "ه"}, Correct = "الف" },
                new QuestionsModel { Word = "Ba", Options = new []{"ب", "ت", "ج"}, Correct = "ب" },
                new QuestionsModel { Word = "Ta", Options = new []{"ت", "ث", "ن"}, Correct = "ت" },
                new QuestionsModel { Word = "Ha", Options = new []{"ه", "د", "ع"}, Correct = "ه" },
                new QuestionsModel { Word = "Jeem", Options = new []{"ج", "ح", "خ"}, Correct = "ج" },
                new QuestionsModel { Word = "Seen", Options = new []{"س", "ص", "ش"}, Correct = "س" },
                new QuestionsModel { Word = "Noon", Options = new []{"ن", "م", "و"}, Correct = "ن" },
                new QuestionsModel { Word = "Meem", Options = new []{"م", "ن", "ه"}, Correct = "م" },
                new QuestionsModel { Word = "Kaf", Options = new []{"ك", "ق", "ف"}, Correct = "ك" },
                new QuestionsModel { Word = "Qaf", Options = new []{"ق", "ك", "ف"}, Correct = "ق" },
            };
        }

        private void DisplayQuestion()
        {
            if (_currentIndex >= _questions.Count)
            {
                ShowResult();
                return;
            }

            var q = _questions[_currentIndex];
            QuestionLabel.Text = q.Word;
            Option1Btn.Text = q.Options[0];
            Option2Btn.Text = q.Options[1];
            Option3Btn.Text = q.Options[2];
            ResetButtons();
            _answered = false;

            // Animate progress (current progress)
            double progress = (double)_currentIndex / _questions.Count;
            AnimateProgress(progress);
        }

        private async void Option_Clicked(object sender, EventArgs e)
        {
            if (_answered) return;

            _answered = true;
            var clickedBtn = (Button)sender;
            var correctAnswer = _questions[_currentIndex].Correct;

            if (clickedBtn.Text == correctAnswer)
            {
                clickedBtn.BackgroundColor = Colors.LightGreen;
                _score++;
            }
            else
            {
                clickedBtn.BackgroundColor = Colors.IndianRed;

                foreach (var btn in new[] { Option1Btn, Option2Btn, Option3Btn })
                {
                    if (btn.Text == correctAnswer)
                        btn.BackgroundColor = Colors.LightGreen;
                }
            }

            await Task.Delay(1500);

            _currentIndex++;
            DisplayQuestion();
        }

        private void ResetButtons()
        {
            foreach (var btn in new[] { Option1Btn, Option2Btn, Option3Btn })
                btn.BackgroundColor = Colors.White;
        }

        private async void ShowResult()
        {
            AnimateProgress(1.0);
            await DisplayAlert("Congratulations!", $"You scored {_score} out of {_questions.Count}!", "OK");
            _currentIndex = 0;
            _score = 0;
            DisplayQuestion();
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

    public class QuestionsModel
    {
        public string Word { get; set; }
        public string[] Options { get; set; }
        public string Correct { get; set; }
    }
}
