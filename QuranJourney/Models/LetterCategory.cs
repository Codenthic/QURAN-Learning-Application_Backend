using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranJourney.Models
{
    public class LetterCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Letters { get; set; } = new();
    }
}
