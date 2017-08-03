using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessMetric.Models;

namespace HappinessMetric.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        //[Authorize]
        public ActionResult UserReport()
        {
            var _HappinessRating = Repository.DatabaseHelper.GetAllRatingDetails();
            return View(_HappinessRating);
        }


    }
}
