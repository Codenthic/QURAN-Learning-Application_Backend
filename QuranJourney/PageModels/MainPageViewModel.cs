using QuranJourney.Pages.Auth;
using QuranJourney.Pages.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuranJourney.PageModels
{
    public class MainPageViewModel
    {
        public ICommand GetStartedCommand { get; }
        public ICommand LoginCommand { get; }

        public INavigation Navigation { get; set; }

        public MainPageViewModel()
        {
            GetStartedCommand = new Command(async () =>
            {
                if (Navigation != null)
                    await Navigation.PushAsync(new WelcomeScreen());
            });

            LoginCommand = new Command(async () =>
            {
                if (Navigation != null)
                    await Navigation.PushAsync(new Login());
            });
        }
    }
}
