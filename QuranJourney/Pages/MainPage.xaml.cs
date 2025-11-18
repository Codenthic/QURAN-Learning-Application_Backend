using Microsoft.UI.Xaml.Media.Animation;
using QuranJourney.Models;
using QuranJourney.PageModels;
using QuranJourney.Pages.Auth;
using QuranJourney.Pages.Courses.Beginner;
using QuranJourney.Pages.Onboarding;
using Syncfusion.Maui.Toolkit.Carousel;

namespace QuranJourney.Pages
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}