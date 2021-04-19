using Bible_Verse_Project.Models;
using Bible_Verse_Project.Services;
using Bible_Verse_Project.Services.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Verse_Project.Controllers
{
    public class VerseController : Controller
    {
        IDataService Data { get; set; }
        private BusinessService service;

        public VerseController(IDataService service)
        {
            Data = service;
            this.service = new BusinessService(Data);
        }

        public IActionResult Search()
        {
            MyLogger.GetInstance().Info("Entering the search page");
            return View();
        }

        [PublicPageLog]
        public IActionResult Create()
        {
            MyLogger.GetInstance().Info("Entering the create page");
            return View();
        }

        public IActionResult SearchResults(string testament, string book, int chapter, int verse)
        {
            BibleVerse result = service.Search(testament, book, chapter, verse);
            ViewBag.Message = "Search Results";
            if (result.Chapter == 0)
            {
                ViewBag.Message = "No Results. Try Adding Your Verse Or Searching Again";
                return View("SearchFailed");
            }
            return View("SearchResults", result);
        }

        public IActionResult DoCreate(string testament, string book, int chapter, int verse, string text)
        {
            ViewBag.Message = "Verse Could Not Be Added. SadFace";
            if (service.Create(testament, book, chapter, verse, text))
                ViewBag.Message = "Verse Added";
            return View("Index");
        }
    }
}
