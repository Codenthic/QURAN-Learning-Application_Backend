using QuranJourney.Pages.Levels_Category;

namespace QuranJourney.Pages.Onboarding;

public partial class CompoundLettersPage : ContentPage
{
    public CompoundLettersPage()
	{
		InitializeComponent();
        TypeTextAsync("Assalamu Alaikum! Start your Quran learning journey here. Choose a category to continue.");
    }
    private async void OnLevelTapped(object sender, TappedEventArgs e)
    {
        string level = e.Parameter?.ToString();

        var page = new LevelCategoriesPage();
        page.Level = level;
        await Navigation.PushAsync(page);
    }

    private async void TypeTextAsync(string message)
    {
        QuestionLabel.Text = string.Empty;

        foreach (char c in message)
        {
            QuestionLabel.Text += c;
            await Task.Delay(45); // typing speed
        }
    }
    private void Back_Tapped(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(".."); // or Navigation.PopAsync();
    }
}