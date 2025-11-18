using Microsoft.Maui;
using QuranJourney.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuranJourney.ViewModels
{
    public class BasicQuestionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int currentIndex = 0;
        private BasicOptionModel selectedOption;
        private double progress;

        public ObservableCollection<BasicOptionModel> Options { get; set; } = new();
        public ObservableCollection<QuestionModel> Questions { get; set; } = new();

        private string questionText;
        public string QuestionText
        {
            get => questionText;
            set { questionText = value; OnPropertyChanged(); }
        }

        public double Progress
        {
            get => progress;
            set { progress = value; OnPropertyChanged(); }
        }

        public ICommand ContinueCommand { get; }
        public ICommand OptionSelectedCommand { get; }

        public BasicQuestionsViewModel()
        {
            LoadQuestions();

            ContinueCommand = new Command(OnContinue);
            OptionSelectedCommand = new Command<BasicOptionModel>(OnOptionSelected);

            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            Questions = new ObservableCollection<QuestionModel>
            {
                new QuestionModel
                {
                    Text = "What would you like to learn?",
                    Options = new List<BasicOptionModel>
                    {
                        new BasicOptionModel { Text = "Arabic" , Image="learn_quran.png" }
                    }
                },
                new QuestionModel
                {
                    Text = "How did you hear about Quran Application?",
                    Options = new List<BasicOptionModel>
                    {
                        new BasicOptionModel { Text = "News/article/blog" },
                        new BasicOptionModel { Text = "TikTok" },
                        new BasicOptionModel { Text = "Google Search" },
                        new BasicOptionModel { Text = "Friend/Family" },
                        new BasicOptionModel { Text = "Facebook/Istagram" },
                        new BasicOptionModel { Text = "App store" },
                        new BasicOptionModel { Text = "TV" },
                        new BasicOptionModel { Text = "YouTube" },
                        new BasicOptionModel { Text = "Other" }
                    }
                },
                new QuestionModel
                {
                    Text = "How much Quran do you know?",
                    Options = new List<BasicOptionModel>
                    {
                        new BasicOptionModel { Text = "I'm new to learning the Quran" },
                        new BasicOptionModel { Text = "I can read a few short Surahs" },
                        new BasicOptionModel { Text = "I can recite basic Surahs with Tajweed" },
                        new BasicOptionModel { Text = "I can read and understand some meanings" },
                        new BasicOptionModel { Text = "I can recite fluently and reflect on meanings" }
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
                     Options = new List<BasicOptionModel> 
                {
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

        private void DisplayQuestion()
        {
            if (currentIndex >= Questions.Count)
            {
                // TODO: Navigate to next page
                return;
            }

            var question = Questions[currentIndex];
            QuestionText = question.Text;

            Options.Clear();
            if (question.Options != null)
            {
                foreach (var opt in question.Options)
                    Options.Add(opt);
            }

            Progress = (double)currentIndex / Questions.Count;
            selectedOption = null;
        }

        private void OnOptionSelected(BasicOptionModel option)
        {
            foreach (var opt in Options)
                opt.IsSelected = false;

            option.IsSelected = true;
            selectedOption = option;
        }

        private void OnContinue()
        {
            if (selectedOption != null)
            {
                if (selectedOption.IsCorrect)
                    selectedOption.BackgroundColor = Microsoft.Maui.Graphics.Colors.LightGreen;
                else
                    selectedOption.BackgroundColor = Microsoft.Maui.Graphics.Colors.LightPink;
            }

            currentIndex++;
            DisplayQuestion();
        }

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
