using QuranJourney.Pages.Courses.Beginner;

namespace QuranJourney.Pages.Onboarding;

public partial class CategorySelection : ContentPage
{
	public CategorySelection()
	{
		InitializeComponent();
	}
    private void Option_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Beginner_Learn_Quran());
    }
}