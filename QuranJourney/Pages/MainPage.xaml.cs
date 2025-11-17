using Microsoft.UI.Xaml.Media.Animation;
using QuranJourney.Models;
using QuranJourney.Pages.Auth;
using QuranJourney.Pages.Courses.Beginner;
using QuranJourney.Pages.Onboarding;

namespace QuranJourney.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        private async void Get_Started(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Beginner_Learning_Quran());

            //await Navigation.PushAsync(new Onboarding.BasicQuestions());
            await Navigation.PushAsync(new WelcomeScreen());
            //await Navigation.PushAsync(new Beginner_Learning_Quran(1, "qaida"));

        }
    }
}