using QuranJourney.Pages.Courses.Beginner;

namespace QuranJourney.Pages.Levels_Category;

public partial class LevelCategoriesPage : ContentPage
{
    public string Level { get; set; }

    public LevelCategoriesPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(Level))
            LoadCategories(Level);
    }

    private void LoadCategories(string level)
    {
        List<string> categoryNames = new();
        List<string> subtitles = new();
        List<string> colors = new();

        // Example: Adjust categories per level
        if (level == "BeginnerQaida")
        {
            categoryNames = new() { "تختی ۱", "تختی ۲", "تختی ۳", "تختی ۴" };
            subtitles = new() { "Qaida Lesson 1", "Qaida Lesson 2", "Qaida Lesson 3", "Qaida Lesson 4" };
            colors = new() { "#58CC02", "#FFA500", "#FF4444", "#FF0000" };
        }
        else if (level == "IntermediateNazra")
        {
            categoryNames = new() { "تختی ۵", "تختی ۶", "تختی ۷", "تختی ۸" };
            subtitles = new() { "Nazra 5", "Nazra 6", "Nazra 7", "Nazra 8" };
            colors = new() { "#58CC02", "#FFA500", "#FF4444", "#FF0000" };
        }
        else if (level == "TajweedRules")
        {
            categoryNames = new() { "تختی ۹", "تختی ۱۰", "تختی ۱۱", "تختی ۱۲" };
            subtitles = new() { "Tajweed 1", "Tajweed 2", "Tajweed 3", "Tajweed 4" };
            colors = new() { "#58CC02", "#FFA500", "#FF4444", "#FF0000" };
        }

        CategoriesGrid.Children.Clear();
        CategoriesGrid.RowDefinitions.Clear();

        int columns = 2;
        int rows = (int)Math.Ceiling((double)categoryNames.Count / columns);

        for (int r = 0; r < rows; r++)
            CategoriesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        for (int i = 0; i < categoryNames.Count; i++)
        {
            int row = i / columns;
            int col = i % columns;

            var frame = CreateCategoryBox(categoryNames[i], subtitles[i], colors[i]);
            CategoriesGrid.Add(frame, col, row);
        }
    }

    private Frame CreateCategoryBox(string title, string subtitle, string color)
    {
        return new Frame
        {
            CornerRadius = 25,
            BorderColor = Color.FromArgb("#C0C0C0"),
            BackgroundColor = Colors.White,
            HeightRequest = 120,
            HasShadow = true,
            Content = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 4,
                Children =
                {
                    new Label
                    {
                        Text = title,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        TextColor = Color.FromArgb(color),
                        HorizontalTextAlignment = TextAlignment.Center
                    },
                    new Label
                    {
                        Text = subtitle,
                        FontSize = 14,
                        TextColor = Color.FromArgb("#555555"),
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            },
            GestureRecognizers =
            {
                new TapGestureRecognizer
                {
                    Command = new Command(() => OnCategoryTapped(title))
                }
            }
        };
    }
    private int ExtractNumberFromThakti(string title)
    {
        // Remove all non-digits (Persian/Urdu digits allowed)
        var digits = new string(title.Where(char.IsDigit).ToArray());

        if (string.IsNullOrEmpty(digits))
            return 1; // default

        // Persian/Urdu digits → English digits conversion
        string englishNumber = digits
            .Replace('۰', '0').Replace('۱', '1').Replace('۲', '2').Replace('۳', '3')
            .Replace('۴', '4').Replace('۵', '5').Replace('۶', '6').Replace('۷', '7')
            .Replace('۸', '8').Replace('۹', '9');

        return int.Parse(englishNumber);
    }

    private async void OnCategoryTapped(string category)
    {
        // Extract number from "تختی ۱" → 1
        int id = ExtractNumberFromThakti(category);

        // Navigate with dynamic ID
        await Navigation.PushAsync(new Beginner_Learning_Quran(id, "qaida"));
    }

}
