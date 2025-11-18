using QuranJourney.PageModels.Onboarding;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuranJourney.Pages.Onboarding;

public partial class WelcomeScreen : ContentPage
{
    public WelcomeScreen()
    {
        InitializeComponent();

        var vm = new WelcomeScreenViewModel();
        vm.Navigation = Navigation;
        BindingContext = vm;
    }
}