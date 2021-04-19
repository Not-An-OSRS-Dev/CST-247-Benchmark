using Bible_Verse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Verse_Project.Services
{
    public interface IDataService
    {
        public bool CreateVerse(BibleVerse verse);

        public BibleVerse Search(string testament, string book, int chapter, int verseNum);
    }
}
