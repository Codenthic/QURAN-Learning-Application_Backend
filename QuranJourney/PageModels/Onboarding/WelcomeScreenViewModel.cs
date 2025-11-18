using QuranJourney.Pages.Onboarding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuranJourney.PageModels.Onboarding
{
    public class WelcomeScreenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ContinueCommand { get; }
        public ICommand BackCommand { get; }

        public INavigation Navigation { get; set; }

        private bool isFirstClick = true;

        private string gifHtml;
        public string GifHtml
        {
            get => gifHtml;
            set { gifHtml = value; OnPropertyChanged(nameof(GifHtml)); }
        }

        private string speechText;
        public string SpeechText
        {
            get => speechText;
            set { speechText = value; OnPropertyChanged(nameof(SpeechText)); }
        }

        public WelcomeScreenViewModel()
        {
            ContinueCommand = new Command(async () => await OnContinue());
            BackCommand = new Command(async () => await OnBack());

            // default speech + first GIF
            SpeechText = "Hi there! I'm Duo!";

            GifHtml = @"
<html>
<body style='margin:0; padding:0; display:flex; justify-content:flex-start; align-items:center; background: transparent; overflow:hidden; height:100%; width:100%;'>
    <img src='giphy.gif' style='width:100%; height:100%; background: transparent; margin-left:20px; display:block;' />
</body>
</html>";
        }

        private async Task OnContinue()
        {
            if (Navigation == null) return;

            if (isFirstClick)
            {
                // Change GIF to next
                GifHtml = @"
<html>
<body style='margin:0; padding:0; display:flex; justify-content:flex-start; align-items:center; background: transparent; overflow:hidden; height:100%; width:100%;'>
    <img src='giphy2.gif' style='width:100%; height:100%; background: transparent; margin-left:20px; display:block;' />
</body>
</html>";

                // Typewriter Effect Text
                SpeechText = "";

                string finalText = "Just 6 quick Questions before we start your first lesson!";
                await ShowTypewriter(finalText);

                isFirstClick = false;
            }
            else
            {
                await Navigation.PushAsync(new BasicQuestions());
            }
        }

        private async Task OnBack()
        {
            if (Navigation != null)
            {
                await Navigation.PopAsync();
            }
        }

        private async Task ShowTypewriter(string text)
        {
            SpeechText = "";
            foreach (char c in text)
            {
                SpeechText += c;
                await Task.Delay(40);
            }
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
