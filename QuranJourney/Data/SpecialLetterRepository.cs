using QuranJourney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranJourney.Data
{
    public static class SpecialLetterRepository
    {
        public static List<LetterCategory> Categories = new List<LetterCategory>
        {
            // 1) Throat Letters
            new LetterCategory
            {
                Id = 1,
                Title = "Throat Letters (Huruf-e-Halqi)",
                Letters = new List<string> { "ط", "غ", "س", "ع", "ہ", "ء" }
            },
        
            // 2) Soft Letters
            new LetterCategory
            {
                Id = 2,
                Title = "Soft Letters",
                Letters = new List<string> { "ظ", "ؽ", "ث" }
            },
        
            // 3) Whistling Letters (Huruf-e-Safeer)
            new LetterCategory
            {
                Id = 3,
                Title = "Whistling Letters (Huruf-e-Safeer)",
                Letters = new List<string> { "ص", "ك", "ف" }
            },
        
            // 4) Heavy Letters (Tafkheem)
            new LetterCategory
            {
                Id = 4,
                Title = "Heavy Letters (Tafkheem)",
                Letters = new List<string> { "ظ", "ق", "ط", "غ", "ض", "ص", "ط" }
            },
        
            // 5) Qalqalah Letters
            new LetterCategory
            {
                Id = 5,
                Title = "Qalqalah Letters",
                Letters = new List<string> { "ػ", "د", "ة", "ط", "ق" }
            },
        
            // 6) Similar Sound Letters
            new LetterCategory
            {
                Id = 6,
                Title = "Similar Sound Letters",
                Letters = new List<string>
                {
                    "ت","ہ","ط","ث","س","ص",
                    "ح","ض","ء","ظ","ع","ق",
                    "ز","ذ","ک"
                }
            }
        };
        public static LetterCategory GetCategoryById(int id)
        {
            return Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
