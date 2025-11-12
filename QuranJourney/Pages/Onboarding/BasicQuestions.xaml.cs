using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuranJourney.Pages.Onboarding;

public partial class BasicQuestions : ContentPage
{


    //private int currentIndex = 0;
    //private List<QuestionModel> questions;
    //private OptionModel selectedOption;
    public BasicQuestions()
    {
        InitializeComponent();
        //LoadQuestionsFromBackend();

        //this.Loaded += async (s, e) =>
        //{
        //    DisplayQuestion();
        //    await Task.Delay(300); // wait for layout measure
        //    AnimateProgress(0.0);
        //};
    }


//    private void LoadQuestionsFromBackend()
//    {
//        // Example data — replace later with backend API
//        questions = new List<QuestionModel>
//        {
//            new QuestionModel { Text = "What would you like to learn?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Spanish", IsCorrect = true },
//                    new OptionModel { Text = "French" },
//                    new OptionModel { Text = "German" },
//                    new OptionModel { Text = "Italian" }
//                } },
//            new QuestionModel { Text = "Which one means 'Hello'?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Hola", IsCorrect = true },
//                    new OptionModel { Text = "Adiós" },
//                    new OptionModel { Text = "Gracias" }
//                } },
//            new QuestionModel { Text = "What is 'Apple' in Spanish?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Manzana", IsCorrect = true },
//                    new OptionModel { Text = "Agua" },
//                    new OptionModel { Text = "Casa" }
//                } },
//            new QuestionModel { Text = "What does 'Gracias' mean?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Thank you", IsCorrect = true },
//                    new OptionModel { Text = "Hello" },
//                    new OptionModel { Text = "Goodbye" }
//                } },
//            new QuestionModel { Text = "Which one means 'Book'?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Libro", IsCorrect = true },
//                    new OptionModel { Text = "Mesa" },
//                    new OptionModel { Text = "Silla" }
//                } },
//            new QuestionModel { Text = "What is 'Cat' in Spanish?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Gato", IsCorrect = true },
//                    new OptionModel { Text = "Perro" },
//                    new OptionModel { Text = "Pez" }
//                } },
//            new QuestionModel { Text = "Which one means 'Water'?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Agua", IsCorrect = true },
//                    new OptionModel { Text = "Leche" },
//                    new OptionModel { Text = "Pan" }
//                } },
//            new QuestionModel { Text = "What is 'House' in Spanish?",
//                Options = new List<OptionModel> {
//                    new OptionModel { Text = "Casa", IsCorrect = true },
//                    new OptionModel { Text = "Coche" },
//                    new OptionModel { Text = "Escuela" }
//                } },
//        };
//    //}

//    //private void DisplayQuestion()
//    //{
//    //    if (currentIndex >= questions.Count)
//    //    {
//    //        QuestionLabel.Text = "🎉 You finished all questions!";
//    //        OptionsList.ItemsSource = null;
//    //        ContinueButton.IsEnabled = false;
//    //        AnimateProgress(1);
//    //        return;
//    //    }

//    //    var question = questions[currentIndex];
//    //    QuestionLabel.Text = question.Text;

//    //    foreach (var opt in question.Options)
//    //    {
//    //        opt.BackgroundColor = Colors.White;
//    //    }

//    //    OptionsList.ItemsSource = new ObservableCollection<OptionModel>(question.Options);
//    //    ContinueButton.IsEnabled = false;
//    //    ContinueButton.BackgroundColor = Color.FromArgb("#E5E5E5");

//    //    double progress = (double)currentIndex / questions.Count;
//    //    AnimateProgress(progress);
//    //}

//    //private void OptionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
//    //{
//    //    if (e.CurrentSelection.Count == 0)
//    //        return;

//    //    var selected = e.CurrentSelection.FirstOrDefault() as OptionModel;
//    //    if (selected == null)
//    //        return;

//    //    // Reset all selections
//    //    foreach (var option in (OptionsList.ItemsSource as IEnumerable<OptionModel>))
//    //        option.IsSelected = false;

//    //    // Mark current one as selected
//    //    selected.IsSelected = true;

//    //    // ✅ Save selection so we can use it in ContinueButton_Clicked
//    //    selectedOption = selected;

//    //    // Optional: enable Continue button
//    //    ContinueButton.IsEnabled = true;
//    //    ContinueButton.BackgroundColor = Color.FromArgb("#58CC02");
//    //}

//    //private async void ContinueButton_Clicked(object sender, EventArgs e)
//    //{
//    //    if (selectedOption == null) return;

//    //    if (selectedOption.IsCorrect)
//    //    {
//    //        await DisplayAlert("✅ Correct!", "Nice job!", "Next");
//    //    }
//    //    else
//    //    {
//    //        await DisplayAlert("❌ Incorrect", "Try again next time!", "Next");
//    //    }

//    //    currentIndex++;
//    //    DisplayQuestion();
//    //}

//    //private async void AnimateProgress(double targetProgress)
//    //{
//    //    // TEMP: force test value
//    //    //targetProgress = 3;

//    //    if (ProgressBarContainer.Width <= 0)
//    //    {
//    //        await Task.Delay(100);
//    //        AnimateProgress(targetProgress);
//    //        return;
//    //    }

//    //    // Clamp progress
//    //    targetProgress = Math.Clamp(targetProgress, 0.0, 1.0);

//    //    double totalWidth = ProgressBarContainer.Width;
//    //    double targetWidth = targetProgress * totalWidth;

//    //    // Cancel any previous animations
//    //    ProgressFill.AbortAnimation("ProgressAnim");

//    //    // Animate WidthRequest property instead of LayoutTo
//    //    var animation = new Animation(v => ProgressFill.WidthRequest = v,
//    //                                  ProgressFill.WidthRequest,
//    //                                  targetWidth);

//    //    animation.Commit(this, "ProgressAnim", 16, 400, Easing.CubicInOut);
//    //}
//}

//public class QuestionModel
//{
//    public string Text { get; set; }
//    public List<OptionModel> Options { get; set; }
//}


//public class OptionModel : INotifyPropertyChanged
//{
//    private bool isSelected;

//    public string Text { get; set; }
//    public string Flag { get; set; }
//    public bool IsCorrect { get; set; }
//    public Color BackgroundColor { get; set; } = Colors.White;

    //public bool IsSelected
    //{
    //    get => isSelected;
    //    set
    //    {
    //        if (isSelected != value)
    //        {
    //            isSelected = value;
    //            OnPropertyChanged(nameof(IsSelected));
    //        }
    //    }
    //}

    //public event PropertyChangedEventHandler PropertyChanged;
    //void OnPropertyChanged(string name) =>
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}