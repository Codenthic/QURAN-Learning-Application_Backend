using QuranJourney.Pages.Courses.Beginner;

namespace QuranJourney.Pages.Onboarding;

public partial class LevelSelection : ContentPage
{
	public LevelSelection()
	{
		InitializeComponent();
        TypeTextAsync("Assalamu Alaikum! Let’s begin your Quran learning journey. Please choose your level to get started.");
    }
    private async  void OnLevelTapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && e.Parameter is string level)
        {
            // Reset all boxes to default
            BeginnerBox.BackgroundColor = Colors.White;
            IntermediateBox.BackgroundColor = Colors.White;
            AdvancedBox.BackgroundColor = Colors.White;

            // Highlight selected
            border.BackgroundColor = Color.FromArgb("#E8FCEB");
            // Optionally navigate or store level
            await Navigation.PushAsync(new LearningCategorySelection());
        }
        await Navigation.PushAsync(new LearningCategorySelection());

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