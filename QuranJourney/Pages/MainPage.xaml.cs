using Microsoft.UI.Xaml.Media.Animation;
using QuranJourney.Models;
using QuranJourney.PageModels;
using QuranJourney.Pages.Auth;
using QuranJourney.Pages.Courses.Beginner;
using QuranJourney.Pages.Onboarding;

namespace QuranJourney.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        private async void Get_Started(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomeScreen());
        }
    }
}