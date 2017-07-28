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

        public static bool hasUserSubmittedForSprint(string username, int sprintId , string projectName)        {

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

    }
}