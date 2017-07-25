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

      
    }
}
