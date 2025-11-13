namespace QuranJourney.Pages.Courses.Beginner;

public partial class Beginner_Correct_Char : ContentPage
{
	public Beginner_Correct_Char()
	{
		InitializeComponent();
	}
    private async void CancleIcon_Tapped(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MainPage());
    }
    private async void CheckBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Beginner_What_You_hear());
    }
}