namespace QuranJourney.Pages.Auth;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private void OnShowPasswordClicked(object sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
    }
    private void OnCloseClicked(object sender, EventArgs e)
    {
        // Close the page
        Navigation.PopAsync();
    }

    private async void OnFacebookTapped(object sender, System.EventArgs e)
    {
        // Handle Facebook login logic
        await DisplayAlert("Facebook", "Facebook login would be implemented here.", "OK");
    }

    private async void OnGoogleTapped(object sender, System.EventArgs e)
    {
        // Handle Google login logic
        await DisplayAlert("Google", "Google login would be implemented here.", "OK");
    }

    private async void OnPrivacyPolicyTapped(object sender, System.EventArgs e)
    {
        // Handle Privacy Policy link tap
        await DisplayAlert("Privacy Policy", "Privacy policy would be displayed here.", "OK");
    }
}