using QuranJourney.Pages.Courses.Beginner;

namespace QuranJourney.Pages.Onboarding;

public partial class SpecialLetterCategoriesPage : ContentPage
{
	public SpecialLetterCategoriesPage()
	{
		InitializeComponent();
	}
    private async void Option_Tapped(object sender, TappedEventArgs e)
    {
        //Navigation.PushAsync(new Beginner_Learning_Quran());
        await Navigation.PushAsync(new Beginner_Learning_Quran(1, "special"));
    }
}