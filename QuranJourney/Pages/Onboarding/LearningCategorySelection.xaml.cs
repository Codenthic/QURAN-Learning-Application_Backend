namespace QuranJourney.Pages.Onboarding;

public partial class LearningCategorySelection : ContentPage
{
	public LearningCategorySelection()
	{
		InitializeComponent();
        TypeTextAsync("Assalamu Alaikum! May Allah bless your intention to learn the Quran. Select a category below and continue your journey toward perfecting Quranic reading and pronunciation.");

    }
    private void OnCategoryTapped(object sender, TappedEventArgs e)
    {
        string selected = e.Parameter.ToString();

        if (selected == "CompoundLetters")
            Navigation.PushAsync(new CompoundLettersPage());

        else if (selected == "SpecialCategories")
            Navigation.PushAsync(new SpecialLetterCategoriesPage());
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