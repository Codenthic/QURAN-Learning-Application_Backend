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

              },

              new LetterCategory
              {
                  Id = 2,
                  Title = "Thakti ۲",
                  QuizItems = new List<LetterQuizItem>
                  {
                      new LetterQuizItem { ArabicLetter="بلب", EnglishLetter="Balab", ArabicOptions=new List<string>{"بلب","باب","تب","لب"}, EnglishOptions=new List<string>{"Balab","Baab","Tab","Lab"}, CorrectArabic="بلب", CorrectEnglish="Balab" },
                      new LetterQuizItem { ArabicLetter="لا", EnglishLetter="La", ArabicOptions=new List<string>{"لا","با","ما","كا"}, EnglishOptions=new List<string>{"La","Ba","Ma","Ka"}, CorrectArabic="لا", CorrectEnglish="La" },

                      new LetterQuizItem { ArabicLetter="با", EnglishLetter="Ba", ArabicOptions=new List<string>{"با","لا","تا","ثا"}, EnglishOptions=new List<string>{"Ba","La","Ta","Tha"}, CorrectArabic="با", CorrectEnglish="Ba" },
                      new LetterQuizItem { ArabicLetter="الا", EnglishLetter="Ala", ArabicOptions=new List<string>{"الا","اللا","با","يا"}, EnglishOptions=new List<string>{"Ala","Alla","Ba","Ya"}, CorrectArabic="الا", CorrectEnglish="Ala" },
              
                      new LetterQuizItem { ArabicLetter="ل", EnglishLetter="Laam", ArabicOptions=new List<string>{"ل","ك","ب","ت"}, EnglishOptions=new List<string>{"Laam","Kaaf","Ba","Ta"}, CorrectArabic="ل", CorrectEnglish="Laam" },
                      new LetterQuizItem { ArabicLetter="لا", EnglishLetter="La", ArabicOptions=new List<string>{"لا","با","تا","ثا"}, EnglishOptions=new List<string>{"La","Ba","Ta","Tha"}, CorrectArabic="لا", CorrectEnglish="La" },
              
                      new LetterQuizItem { ArabicLetter="لب", EnglishLetter="Lab", ArabicOptions=new List<string>{"لب","بب","با","لا"}, EnglishOptions=new List<string>{"Lab","Bab","Ba","La"}, CorrectArabic="لب", CorrectEnglish="Lab" },
              
                      new LetterQuizItem { ArabicLetter="مح", EnglishLetter="Mah", ArabicOptions=new List<string>{"مح","حم","ما","كا"}, EnglishOptions=new List<string>{"Mah","Ham","Ma","Ka"}, CorrectArabic="مح", CorrectEnglish="Mah" },
                      new LetterQuizItem { ArabicLetter="لح", EnglishLetter="Lah", ArabicOptions=new List<string>{"لح","حل","لا","بل"}, EnglishOptions=new List<string>{"Lah","Hal","La","Bal"}, CorrectArabic="لح", CorrectEnglish="Lah" },
              
                      new LetterQuizItem { ArabicLetter="ك", EnglishLetter="Kaaf", ArabicOptions=new List<string>{"ك","ق","ف","ل"}, EnglishOptions=new List<string>{"Kaaf","Qaf","Fa","Laam"}, CorrectArabic="ك", CorrectEnglish="Kaaf" },
                      new LetterQuizItem { ArabicLetter="كا", EnglishLetter="Kaa", ArabicOptions=new List<string>{"كا","ك","با","لا"}, EnglishOptions=new List<string>{"Kaa","Kaaf","Ba","La"}, CorrectArabic="كا", CorrectEnglish="Kaa" },
              
                      new LetterQuizItem { ArabicLetter="كبا", EnglishLetter="Kaba", ArabicOptions=new List<string>{"كبا","باك","كا","كب"}, EnglishOptions=new List<string>{"Kaba","Bak","Kaa","Kab"}, CorrectArabic="كبا", CorrectEnglish="Kaba" },
                      new LetterQuizItem { ArabicLetter="كب", EnglishLetter="Kab", ArabicOptions=new List<string>{"كب","بك","كا","لا"}, EnglishOptions=new List<string>{"Kab","Bak","Kaa","La"}, CorrectArabic="كب", CorrectEnglish="Kab" },
              
                      new LetterQuizItem { ArabicLetter="بكت", EnglishLetter="Bakt", ArabicOptions=new List<string>{"بكت","بتك","كبت","بكت"}, EnglishOptions=new List<string>{"Bakt","Batk","Kabt","Bakt"}, CorrectArabic="بكت", CorrectEnglish="Bakt" },
                      new LetterQuizItem { ArabicLetter="تدث", EnglishLetter="Tadth", ArabicOptions=new List<string>{"تدث","تثد","دثت","تد"}, EnglishOptions=new List<string>{"Tadth","Tathd","Dath","Tad"}, CorrectArabic="تدث", CorrectEnglish="Tadth" },
              
                      new LetterQuizItem { ArabicLetter="ت", EnglishLetter="Ta", ArabicOptions=new List<string>{"ت","ث","ب","ن"}, EnglishOptions=new List<string>{"Ta","Tha","Ba","Noon"}, CorrectArabic="ت", CorrectEnglish="Ta" },
                      new LetterQuizItem { ArabicLetter="ب", EnglishLetter="Ba", ArabicOptions=new List<string>{"ب","ت","ث","ن"}, EnglishOptions=new List<string>{"Ba","Ta","Tha","Noon"}, CorrectArabic="ب", CorrectEnglish="Ba" },
              
                      new LetterQuizItem { ArabicLetter="ثا", EnglishLetter="Thaa", ArabicOptions=new List<string>{"ثا","تا","سا","شا"}, EnglishOptions=new List<string>{"Thaa","Taa","Saa","Shaa"}, CorrectArabic="ثا", CorrectEnglish="Thaa" },
                      new LetterQuizItem { ArabicLetter="با", EnglishLetter="Baa", ArabicOptions=new List<string>{"با","ثا","تا","شا"}, EnglishOptions=new List<string>{"Baa","Thaa","Taa","Shaa"}, CorrectArabic="با", CorrectEnglish="Baa" },
              
                      new LetterQuizItem { ArabicLetter="يا", EnglishLetter="Yaa", ArabicOptions=new List<string>{"يا","با","تا","ثا"}, EnglishOptions=new List<string>{"Yaa","Baa","Taa","Thaa"}, CorrectArabic="يا", CorrectEnglish="Yaa" },
                      new LetterQuizItem { ArabicLetter="نا", EnglishLetter="Naa", ArabicOptions=new List<string>{"نا","يا","تا","ثا"}, EnglishOptions=new List<string>{"Naa","Yaa","Taa","Thaa"}, CorrectArabic="نا", CorrectEnglish="Naa" },
              
                      new LetterQuizItem { ArabicLetter="نس", EnglishLetter="Nas", ArabicOptions=new List<string>{"نس","سن","س","نا"}, EnglishOptions=new List<string>{"Nas","San","Sa","Naa"}, CorrectArabic="نس", CorrectEnglish="Nas" },
                      new LetterQuizItem { ArabicLetter="تس", EnglishLetter="Tas", ArabicOptions=new List<string>{"تس","ست","نس","تا"}, EnglishOptions=new List<string>{"Tas","Sat","Nas","Taa"}, CorrectArabic="تس", CorrectEnglish="Tas" },
              
                      new LetterQuizItem { ArabicLetter="شا", EnglishLetter="Shaa", ArabicOptions=new List<string>{"شا","سا","ش","ثا"}, EnglishOptions=new List<string>{"Shaa","Saa","Sh","Thaa"}, CorrectArabic="شا", CorrectEnglish="Shaa" },
                      new LetterQuizItem { ArabicLetter="يا", EnglishLetter="Yaa", ArabicOptions=new List<string>{"يا","شا","سا","ش"}, EnglishOptions=new List<string>{"Yaa","Shaa","Saa","Sh"}, CorrectArabic="يا", CorrectEnglish="Yaa" },
              
                      new LetterQuizItem { ArabicLetter="يس", EnglishLetter="Yas", ArabicOptions=new List<string>{"يس","سي","شس","سا"}, EnglishOptions=new List<string>{"Yas","See","Shas","Saa"}, CorrectArabic="يس", CorrectEnglish="Yas" },
                      new LetterQuizItem { ArabicLetter="بس", EnglishLetter="Bas", ArabicOptions=new List<string>{"بس","سب","س","با"}, EnglishOptions=new List<string>{"Bas","Sab","Sa","Ba"}, CorrectArabic="بس", CorrectEnglish="Bas" },
              
                      new LetterQuizItem { ArabicLetter="شج", EnglishLetter="Shaj", ArabicOptions=new List<string>{"شج","جش","شا","جا"}, EnglishOptions=new List<string>{"Shaj","Jash","Shaa","Ja"}, CorrectArabic="شج", CorrectEnglish="Shaj" },
                      new LetterQuizItem { ArabicLetter="تج", EnglishLetter="Taj", ArabicOptions=new List<string>{"تج","جت","تا","جا"}, EnglishOptions=new List<string>{"Taj","Jat","Taa","Ja"}, CorrectArabic="تج", CorrectEnglish="Taj" }
                  }
              }

        };
        public static LetterCategory GetQaidaCategoryById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
