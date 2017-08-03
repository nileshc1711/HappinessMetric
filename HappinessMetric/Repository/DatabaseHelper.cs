using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Repository
{
    public static class DatabaseHelper
    {
        private const int _currentSprint = 58;
        public static void SaveUserFeedback(HappinessRating happinessRating)
        {
            
            using (var _context = new DbDataContext())
            {
                happinessRating.CreatedOn = DateTime.Now;
                _context.HappinessRatings.InsertOnSubmit(happinessRating);
                _context.SubmitChanges();
            }
        }

        public static bool HasUserSubmittedForSprint(string username, int sprintId , string projectName)        {

            using (var _context = new DbDataContext())
            {
               
                return _context.HappinessRatings.Any(x => x.Developer.Equals(username) && x.Project.Equals(projectName) && x.Sprint == sprintId);
            }
        }

        public static List<HappinessRating> GetAllRatingDetails()
        {
            using (var _context = new DbDataContext())
            {
                var RatingDetails = _context.HappinessRatings.Select(s => s);
                return RatingDetails.ToList();
            }
        }

        public static bool AuthenticateUser(string username)
        {
            var isValid = false;
            using (var _context = new DbDataContext())
            {
                isValid = _context.Users.Any(x => x.us_username.Equals(username) && x.us_isactive == 1);
            }
            return isValid;
        }
        public static Project_Sprint_Detail GetSprintNo(string username)
        {
                     
            using (var _context = new DbDataContext())
            {
                var sprintDetails = new Project_Sprint_Detail();
                var  projIDs = (from US in _context.Users
                             join PU in _context.Project_User_Juncs on US.us_id equals PU.pu_userId
                             join PJ in _context.Projects on PU.pu_projectId equals PJ.pj_id
                             where (US.us_username == username)
                             select new {                             
                                 projID = PJ.pj_parent == 0 ? PJ.pj_id : PJ.pj_parent
                             }).SingleOrDefault();

                sprintDetails = (from PSD in _context.Project_Sprint_Details
                                 where (PSD.ps_projectId == projIDs.projID)
                                 select PSD).SingleOrDefault();
                 return sprintDetails;
                           
            }
           
        }


    }
}