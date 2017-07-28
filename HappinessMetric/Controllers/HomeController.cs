using HappinessMetric.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinessMetric.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userViewModel = new UserViewModel
            {
                LanID = Request.LogonUserIdentity.Name
            };

            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Index(Repository.HappinessRating SubmittedRating)
        {
            var userViewModel = new UserViewModel
            {
                LanID = Request.LogonUserIdentity.Name
            };

            if (!Repository.DatabaseHelper.HasUserSubmittedForSprint(SubmittedRating.Developer, (int)SubmittedRating.Sprint, SubmittedRating.Project))
            {
                Repository.DatabaseHelper.SaveUserFeedback(SubmittedRating);
            }
            else
            {
                userViewModel.hasUserSubmittedForCurrentSprint = true;
            }
            return Json(userViewModel);

        }
        [HttpPost]
        public JsonResult GetSprintNo()
        {

            UserViewModel usermodel = new UserViewModel();
            var data = usermodel.LastThreeSprints;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
