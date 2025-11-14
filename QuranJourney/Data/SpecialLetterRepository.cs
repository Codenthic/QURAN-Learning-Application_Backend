using QuranJourney.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuranJourney.Data
{
    public static class SpecialLetterRepository
    {
        public static List<LetterCategory> Categories = new List<LetterCategory>
        {
            // 1) Throat Letters (Huruf-e-Halqi)
            new LetterCategory
            {
                Id = 1,
                Title = "Throat Letters (Huruf-e-Halqi)",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ط",
                        EnglishLetter = "Taa",
                        ArabicOptions = new List<string> { "ط", "غ", "س", "ع" },
                        EnglishOptions = new List<string> { "Taa", "Ghain", "Seen", "Ayn" },
                        CorrectArabic = "ط",
                        CorrectEnglish = "Taa"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "غ",
                        EnglishLetter = "Ghain",
                        ArabicOptions = new List<string> { "غ", "ع", "ہ", "ء" },
                        EnglishOptions = new List<string> { "Ghain", "Ayn", "Heh", "Hamza" },
                        CorrectArabic = "غ",
                        CorrectEnglish = "Ghain"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "س",
                        EnglishLetter = "Seen",
                        ArabicOptions = new List<string> { "س", "ص", "ط", "غ" },
                        EnglishOptions = new List<string> { "Seen", "Saad", "Taa", "Ghain" },
                        CorrectArabic = "س",
                        CorrectEnglish = "Seen"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ع",
                        EnglishLetter = "Ayn",
                        ArabicOptions = new List<string> { "ع", "غ", "ہ", "ء" },
                        EnglishOptions = new List<string> { "Ayn", "Ghain", "Heh", "Hamza" },
                        CorrectArabic = "ع",
                        CorrectEnglish = "Ayn"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ہ",
                        EnglishLetter = "Heh",
                        ArabicOptions = new List<string> { "ہ", "ء", "ط", "غ" },
                        EnglishOptions = new List<string> { "Heh", "Hamza", "Taa", "Ghain" },
                        CorrectArabic = "ہ",
                        CorrectEnglish = "Heh"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ء",
                        EnglishLetter = "Hamza",
                        ArabicOptions = new List<string> { "ء", "ہ", "ع", "غ" },
                        EnglishOptions = new List<string> { "Hamza", "Heh", "Ayn", "Ghain" },
                        CorrectArabic = "ء",
                        CorrectEnglish = "Hamza"
                    }
                }
            },

            // 2) Soft Letters
            new LetterCategory
            {
                Id = 2,
                Title = "Soft Letters",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ظ",
                        EnglishLetter = "Zaa",
                        ArabicOptions = new List<string> { "ظ", "ث", "س" },
                        EnglishOptions = new List<string> { "Zaa", "Sa", "Seen" },
                        CorrectArabic = "ظ",
                        CorrectEnglish = "Zaa"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ؽ",
                        EnglishLetter = "Ghayn Soft",
                        ArabicOptions = new List<string> { "ؽ", "ث", "س" },
                        EnglishOptions = new List<string> { "Ghayn Soft", "Sa", "Seen" },
                        CorrectArabic = "ؽ",
                        CorrectEnglish = "Ghayn Soft"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ث",
                        EnglishLetter = "Sa",
                        ArabicOptions = new List<string> { "ث", "س", "ص" },
                        EnglishOptions = new List<string> { "Sa", "Seen", "Saad" },
                        CorrectArabic = "ث",
                        CorrectEnglish = "Sa"
                    }
                }
            },

            // 3) Whistling Letters (Huruf-e-Safeer)
            new LetterCategory
            {
                Id = 3,
                Title = "Whistling Letters (Huruf-e-Safeer)",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ص",
                        EnglishLetter = "Saad",
                        ArabicOptions = new List<string> { "ص", "س", "ف" },
                        EnglishOptions = new List<string> { "Saad", "Seen", "Fa" },
                        CorrectArabic = "ص",
                        CorrectEnglish = "Saad"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ك",
                        EnglishLetter = "Kaaf",
                        ArabicOptions = new List<string> { "ك", "ف", "س" },
                        EnglishOptions = new List<string> { "Kaaf", "Fa", "Seen" },
                        CorrectArabic = "ك",
                        CorrectEnglish = "Kaaf"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ف",
                        EnglishLetter = "Fa",
                        ArabicOptions = new List<string> { "ف", "ص", "ك" },
                        EnglishOptions = new List<string> { "Fa", "Saad", "Kaaf" },
                        CorrectArabic = "ف",
                        CorrectEnglish = "Fa"
                    }
                }
            },

            // 4) Heavy Letters (Tafkheem)
            new LetterCategory
            {
                Id = 4,
                Title = "Heavy Letters (Tafkheem)",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ق",
                        EnglishLetter = "Qaf",
                        ArabicOptions = new List<string> { "ق", "ط", "غ" },
                        EnglishOptions = new List<string> { "Qaf", "Taa", "Ghain" },
                        CorrectArabic = "ق",
                        CorrectEnglish = "Qaf"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ط",
                        EnglishLetter = "Taa",
                        ArabicOptions = new List<string> { "ط", "ص", "ظ" },
                        EnglishOptions = new List<string> { "Taa", "Saad", "Zaa" },
                        CorrectArabic = "ط",
                        CorrectEnglish = "Taa"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "غ",
                        EnglishLetter = "Ghain",
                        ArabicOptions = new List<string> { "غ", "ق", "ظ" },
                        EnglishOptions = new List<string> { "Ghain", "Qaf", "Zaa" },
                        CorrectArabic = "غ",
                        CorrectEnglish = "Ghain"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ض",
                        EnglishLetter = "Daad",
                        ArabicOptions = new List<string> { "ض", "ص", "س" },
                        EnglishOptions = new List<string> { "Daad", "Saad", "Seen" },
                        CorrectArabic = "ض",
                        CorrectEnglish = "Daad"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ص",
                        EnglishLetter = "Saad",
                        ArabicOptions = new List<string> { "ص", "س", "ط" },
                        EnglishOptions = new List<string> { "Saad", "Seen", "Taa" },
                        CorrectArabic = "ص",
                        CorrectEnglish = "Saad"
                    }
                }
            },

            // 5) Qalqalah Letters
            new LetterCategory
            {
                Id = 5,
                Title = "Qalqalah Letters",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ػ",
                        EnglishLetter = "Qa Soft",
                        ArabicOptions = new List<string> { "ػ", "د", "ق" },
                        EnglishOptions = new List<string> { "Qa Soft", "Dal", "Qaf" },
                        CorrectArabic = "ػ",
                        CorrectEnglish = "Qa Soft"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "د",
                        EnglishLetter = "Dal",
                        ArabicOptions = new List<string> { "د", "ق", "ط" },
                        EnglishOptions = new List<string> { "Dal", "Qaf", "Taa" },
                        CorrectArabic = "د",
                        CorrectEnglish = "Dal"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ة",
                        EnglishLetter = "Taa Marbuta",
                        ArabicOptions = new List<string> { "ة", "ط", "ق" },
                        EnglishOptions = new List<string> { "Taa Marbuta", "Taa", "Qaf" },
                        CorrectArabic = "ة",
                        CorrectEnglish = "Taa Marbuta"
                    }
                }
            },

            // 6) Similar Sound Letters (Homophones)
            new LetterCategory
            {
                Id = 6,
                Title = "Similar Sound Letters (Homophones)",
                QuizItems = new List<LetterQuizItem>
                {
                    new LetterQuizItem
                    {
                        ArabicLetter = "ت",
                        EnglishLetter = "Taa",
                        ArabicOptions = new List<string> { "ت", "ث", "ط" },
                        EnglishOptions = new List<string> { "Taa", "Sa", "Taa Heavy" },
                        CorrectArabic = "ت",
                        CorrectEnglish = "Taa"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "س",
                        EnglishLetter = "Seen",
                        ArabicOptions = new List<string> { "س", "ص", "ث" },
                        EnglishOptions = new List<string> { "Seen", "Saad", "Sa" },
                        CorrectArabic = "س",
                        CorrectEnglish = "Seen"
                    },
                    new LetterQuizItem
                    {
                        ArabicLetter = "ض",
                        EnglishLetter = "Daad",
                        ArabicOptions = new List<string> { "ض", "ص", "ظ" },
                        EnglishOptions = new List<string> { "Daad", "Saad", "Zaa" },
                        CorrectArabic = "ض",
                        CorrectEnglish = "Daad"
                    }
                }
            }
        };

        public static LetterCategory GetCategoryById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
