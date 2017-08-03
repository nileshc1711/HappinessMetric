﻿using HappinessMetric.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessMetric.Utilities;

namespace HappinessMetric.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            var userViewModel = new UserViewModel();
            userViewModel.LanID = Request.LogonUserIdentity.Name;
            userViewModel.isValid = Repository.DatabaseHelper.AuthenticateUser(userViewModel.UserName);
           // userViewModel.CurrentSprint = Repository.DatabaseHelper.GetSprintNo(userViewModel.UserName);
           userViewModel.CurrentSprint = SprintCalculator.GetSprintNo(userViewModel.UserName);
           userViewModel.LastThreeSprints = SprintCalculator.GetLast3SprintNo(userViewModel.CurrentSprint);
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
                userViewModel.HasUserSubmittedForCurrentSprint = true;
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
