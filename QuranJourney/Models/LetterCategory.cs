using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranJourney.Models
{
    public class LetterQuizItem
    {
        public string ArabicLetter { get; set; }
        public string EnglishLetter { get; set; }

        public List<string> ArabicOptions { get; set; }
        public List<string> EnglishOptions { get; set; } 

        public string CorrectArabic { get; set; }
        public string CorrectEnglish { get; set; }
    }
    public class LetterCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Letters { get; set; } = new();
        public List<LetterQuizItem> QuizItems { get; set; } = new();
    }

}
