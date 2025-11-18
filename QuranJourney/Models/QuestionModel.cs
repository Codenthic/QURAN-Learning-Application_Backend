using System.ComponentModel;

namespace QuranJourney.Models
{
    public class QuestionModel
    {
        public string Text { get; set; }    // Must be settable
        public List<BasicOptionModel> Options { get; set; } = new(); // Must be settable
    }

    public class BasicOptionModel : INotifyPropertyChanged
    {
        private bool isSelected;

        public string Text { get; set; }
        public string Flag { get; set; }
        public bool IsCorrect { get; set; }
        public string Image { get; set; }

        // MAUI Color
        public Microsoft.Maui.Graphics.Color BackgroundColor { get; set; } = Microsoft.Maui.Graphics.Colors.White;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
