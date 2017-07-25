using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinessMetric.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult UserReport()
        {
            return View();
        }

    }
}
