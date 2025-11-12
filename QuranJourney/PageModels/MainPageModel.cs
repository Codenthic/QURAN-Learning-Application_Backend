using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using QuranJourney.Models;
using QuranJourney.Pages.Auth;

namespace QuranJourney.PageModels
{
    public partial class MainPageModel : ObservableObject
    {
        private bool _isNavigatedTo;
        private bool _dataLoaded;
       
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        bool _isRefreshing;

        [ObservableProperty]
        private string _today = DateTime.Now.ToString("dddd, MMM d");

        [RelayCommand]
        private Task GetStarted() => Shell.Current.GoToAsync(nameof(LoginBtn));

        [RelayCommand]
        //private Task LoginBtn() => Shell.Current.GoToAsync(nameof(Login));
        private Task LoginBtn() =>Shell.Current.GoToAsync("Login");
    }
}