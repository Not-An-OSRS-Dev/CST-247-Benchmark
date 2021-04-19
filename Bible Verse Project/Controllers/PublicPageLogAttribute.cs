using Bible_Verse_Project.Services.Utility;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Bible_Verse_Project.Controllers
{
    internal class PublicPageLogAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            MyLogger log = MyLogger.GetInstance();
            MyLogger.GetInstance().Info("Entering Page ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin method");
        }
    }
}