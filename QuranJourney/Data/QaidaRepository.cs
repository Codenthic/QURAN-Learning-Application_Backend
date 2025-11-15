using QuranJourney.Models;
using System.Collections.Generic;

namespace QuranJourney.Data
{
    public static class ThaktiRepository
    {
        public static List<LetterCategory> Categories = new List<LetterCategory>
        {
              new LetterCategory
              {
                 Id = 1,
                 Title = "Thakti ۱",
                 QuizItems = new List<LetterQuizItem>
                 {
                     new LetterQuizItem { ArabicLetter="ا", EnglishLetter="Alif", ArabicOptions=new List<string>{"ا","ب","ت","ث"}, EnglishOptions=new List<string>{"Alif","Ba","Ta","Tha"}, CorrectArabic="ا", CorrectEnglish="Alif" },
                     new LetterQuizItem { ArabicLetter="ب", EnglishLetter="Ba", ArabicOptions=new List<string>{"ب","ا","ت","ث"}, EnglishOptions=new List<string>{"Ba","Alif","Ta","Tha"}, CorrectArabic="ب", CorrectEnglish="Ba" },
                     new LetterQuizItem { ArabicLetter="ت", EnglishLetter="Ta", ArabicOptions=new List<string>{"ت","ب","ث","ج"}, EnglishOptions=new List<string>{"Ta","Ba","Tha","Jeem"}, CorrectArabic="ت", CorrectEnglish="Ta" },
                     new LetterQuizItem { ArabicLetter="ث", EnglishLetter="Tha", ArabicOptions=new List<string>{"ث","ت","ج","ح"}, EnglishOptions=new List<string>{"Tha","Ta","Jeem","Haa"}, CorrectArabic="ث", CorrectEnglish="Tha" },
                     new LetterQuizItem { ArabicLetter="ج", EnglishLetter="Jeem", ArabicOptions=new List<string>{"ج","ح","خ","د"}, EnglishOptions=new List<string>{"Jeem","Haa","Khaa","Dal"}, CorrectArabic="ج", CorrectEnglish="Jeem" },
                     new LetterQuizItem { ArabicLetter="ح", EnglishLetter="Haa", ArabicOptions=new List<string>{"ح","خ","ج","د"}, EnglishOptions=new List<string>{"Haa","Khaa","Jeem","Dal"}, CorrectArabic="ح", CorrectEnglish="Haa" },
                     new LetterQuizItem { ArabicLetter="خ", EnglishLetter="Khaa", ArabicOptions=new List<string>{"خ","ح","ج","د"}, EnglishOptions=new List<string>{"Khaa","Haa","Jeem","Dal"}, CorrectArabic="خ", CorrectEnglish="Khaa" },
                     new LetterQuizItem { ArabicLetter="د", EnglishLetter="Dal", ArabicOptions=new List<string>{"د","ذ","ر","ز"}, EnglishOptions=new List<string>{"Dal","Dhal","Ra","Zay"}, CorrectArabic="د", CorrectEnglish="Dal" },
                     new LetterQuizItem { ArabicLetter="ذ", EnglishLetter="Dhal", ArabicOptions=new List<string>{"ذ","د","ر","ز"}, EnglishOptions=new List<string>{"Dhal","Dal","Ra","Zay"}, CorrectArabic="ذ", CorrectEnglish="Dhal" },
                     new LetterQuizItem { ArabicLetter="ر", EnglishLetter="Ra", ArabicOptions=new List<string>{"ر","ز","س","ش"}, EnglishOptions=new List<string>{"Ra","Zay","Seen","Sheen"}, CorrectArabic="ر", CorrectEnglish="Ra" },
                     new LetterQuizItem { ArabicLetter="ز", EnglishLetter="Zay", ArabicOptions=new List<string>{"ز","ر","س","ش"}, EnglishOptions=new List<string>{"Zay","Ra","Seen","Sheen"}, CorrectArabic="ز", CorrectEnglish="Zay" },
                     new LetterQuizItem { ArabicLetter="س", EnglishLetter="Seen", ArabicOptions=new List<string>{"س","ش","ص","ض"}, EnglishOptions=new List<string>{"Seen","Sheen","Saad","Daad"}, CorrectArabic="س", CorrectEnglish="Seen" },
                     new LetterQuizItem { ArabicLetter="ش", EnglishLetter="Sheen", ArabicOptions=new List<string>{"ش","س","ص","ض"}, EnglishOptions=new List<string>{"Sheen","Seen","Saad","Daad"}, CorrectArabic="ش", CorrectEnglish="Sheen" },
                     new LetterQuizItem { ArabicLetter="ص", EnglishLetter="Saad", ArabicOptions=new List<string>{"ص","س","ض","ط"}, EnglishOptions=new List<string>{"Saad","Seen","Daad","Taa"}, CorrectArabic="ص", CorrectEnglish="Saad" },
                     new LetterQuizItem { ArabicLetter="ض", EnglishLetter="Daad", ArabicOptions=new List<string>{"ض","ص","ط","ظ"}, EnglishOptions=new List<string>{"Daad","Saad","Taa","Zaa"}, CorrectArabic="ض", CorrectEnglish="Daad" },
                     new LetterQuizItem { ArabicLetter="ط", EnglishLetter="Taa", ArabicOptions=new List<string>{"ط","ظ","ع","غ"}, EnglishOptions=new List<string>{"Taa","Zaa","Ayn","Ghain"}, CorrectArabic="ط", CorrectEnglish="Taa" },
                     new LetterQuizItem { ArabicLetter="ظ", EnglishLetter="Zaa", ArabicOptions=new List<string>{"ظ","ط","ع","غ"}, EnglishOptions=new List<string>{"Zaa","Taa","Ayn","Ghain"}, CorrectArabic="ظ", CorrectEnglish="Zaa" },
                     new LetterQuizItem { ArabicLetter="ع", EnglishLetter="Ayn", ArabicOptions=new List<string>{"ع","غ","ف","ق"}, EnglishOptions=new List<string>{"Ayn","Ghain","Fa","Qaf"}, CorrectArabic="ع", CorrectEnglish="Ayn" },
                     new LetterQuizItem { ArabicLetter="غ", EnglishLetter="Ghain", ArabicOptions=new List<string>{"غ","ع","ف","ق"}, EnglishOptions=new List<string>{"Ghain","Ayn","Fa","Qaf"}, CorrectArabic="غ", CorrectEnglish="Ghain" },
                     new LetterQuizItem { ArabicLetter="ف", EnglishLetter="Fa", ArabicOptions=new List<string>{"ف","ق","ك","ل"}, EnglishOptions=new List<string>{"Fa","Qaf","Kaaf","Laam"}, CorrectArabic="ف", CorrectEnglish="Fa" },
                     new LetterQuizItem { ArabicLetter="ق", EnglishLetter="Qaf", ArabicOptions=new List<string>{"ق","ف","ك","ل"}, EnglishOptions=new List<string>{"Qaf","Fa","Kaaf","Laam"}, CorrectArabic="ق", CorrectEnglish="Qaf" },
                     new LetterQuizItem { ArabicLetter="ك", EnglishLetter="Kaaf", ArabicOptions=new List<string>{"ك","ق","ل","م"}, EnglishOptions=new List<string>{"Kaaf","Qaf","Laam","Meem"}, CorrectArabic="ك", CorrectEnglish="Kaaf" },
                     new LetterQuizItem { ArabicLetter="ل", EnglishLetter="Laam", ArabicOptions=new List<string>{"ل","ك","م","ن"}, EnglishOptions=new List<string>{"Laam","Kaaf","Meem","Noon"}, CorrectArabic="ل", CorrectEnglish="Laam" },
                     new LetterQuizItem { ArabicLetter="م", EnglishLetter="Meem", ArabicOptions=new List<string>{"م","ل","ن","ه"}, EnglishOptions=new List<string>{"Meem","Laam","Noon","Heh"}, CorrectArabic="م", CorrectEnglish="Meem" },
                     new LetterQuizItem { ArabicLetter="ن", EnglishLetter="Noon", ArabicOptions=new List<string>{"ن","م","ه","و"}, EnglishOptions=new List<string>{"Noon","Meem","Heh","Waw"}, CorrectArabic="ن", CorrectEnglish="Noon" },
                     new LetterQuizItem { ArabicLetter="ه", EnglishLetter="Heh", ArabicOptions=new List<string>{"ه","ن","و","ي"}, EnglishOptions=new List<string>{"Heh","Noon","Waw","Ya"}, CorrectArabic="ه", CorrectEnglish="Heh" },
                     new LetterQuizItem { ArabicLetter="و", EnglishLetter="Waw", ArabicOptions=new List<string>{"و","ه","ي","ا"}, EnglishOptions=new List<string>{"Waw","Heh","Ya","Alif"}, CorrectArabic="و", CorrectEnglish="Waw" },
                     new LetterQuizItem { ArabicLetter="ي", EnglishLetter="Ya", ArabicOptions=new List<string>{"ي","و","ه","ا"}, EnglishOptions=new List<string>{"Ya","Waw","Heh","Alif"}, CorrectArabic="ي", CorrectEnglish="Ya" }
                 }
              }
        };
        public static LetterCategory GetQaidaCategoryById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
