using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Verse_Project.Models
{
    public class BibleVerse
    {
        [DisplayName("Testament")]
        [Required]
        public string Testament { get; set; }

        [Required]
        [DisplayName("Book Name")]
        public string Book { get; set; }

        [Required]
        [DisplayName("Chapter Number")]
        public int Chapter { get; set; }

        [Required]
        [DisplayName("Verse Number")]
        public int Verse { get; set; }

        [DisplayName("Verse Text")]
        public string Text { get; set; }

        public BibleVerse()
        {
        }

        public BibleVerse(string testament, string book, int chapter, int verse, string text)
        {
            Testament = testament;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
        }
    }
}
