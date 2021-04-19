using Bible_Verse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Verse_Project.Services
{
    public class BusinessService
    {
        public IDataService Data;

        public BusinessService(IDataService service)
        {
            Data = service;
        }

        public BibleVerse Search(string testament, string book, int chapter, int verseNum)
        {
            Data = new DataService();
            BibleVerse verse = Data.Search(testament, book, chapter, verseNum);
            return verse;
        }

        public bool Create(string testament, string book, int chapter, int verseNum, string text)
        {
            BibleVerse verse = new BibleVerse();
            Data = new DataService();

            verse.Testament = testament;
            verse.Book = book;
            verse.Chapter = chapter;
            verse.Verse = verseNum;
            verse.Text = text;

            bool success = Data.CreateVerse(verse);

            return success;
        }
    }
}
