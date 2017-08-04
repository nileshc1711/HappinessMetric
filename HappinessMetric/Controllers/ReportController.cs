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

        public ActionResult UserReport()
        {
            var userViewModel = new UserViewModel();
            userViewModel.LanID = Request.LogonUserIdentity.Name;
            userViewModel.isValid = Repository.DatabaseHelper.AuthenticateUser(userViewModel.UserName);
            if (userViewModel.isValid && userViewModel.IsAdmin)
            {
                var _HappinessRating = Repository.DatabaseHelper.GetAllRatingDetails();
                return View(_HappinessRating);
            }
            else
            {
                return View("ErrorPage");
            }
        }


    }
}
