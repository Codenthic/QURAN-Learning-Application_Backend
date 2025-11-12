namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Learn_Quran : ContentPage
{
	public Beginner_Learn_Quran()
	{
		InitializeComponent();
	}
    private async void SpeakerButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var textToSpeak = "دو"; // Arabic word
            await TextToSpeech.Default.SpeakAsync(textToSpeak);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Cannot play audio: {ex.Message}", "OK");
        }
    }
}