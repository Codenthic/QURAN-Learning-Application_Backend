using QuranJourney.Pages.Courses.Beginner;

namespace QuranJourney.Pages.Onboarding;

public partial class SpecialLetterCategoriesPage : ContentPage
{
	public SpecialLetterCategoriesPage()
	{
		InitializeComponent();
	}
    private void Option_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Beginner_Learning_Quran());
    }
}