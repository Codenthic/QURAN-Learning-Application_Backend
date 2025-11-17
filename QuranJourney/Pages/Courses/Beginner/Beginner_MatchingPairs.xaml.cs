namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_MatchingPairs : ContentPage
{
	public Beginner_MatchingPairs()
	{
		InitializeComponent();
	}
    private async void ChkButton(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Beginner_Select_Word());
    }
}