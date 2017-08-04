using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Models
{
    public class UserViewModel
    {
        public string LanID { get; set; }
        public bool HasUserSubmittedForCurrentSprint { get; set; }
        public string UserName
        {
            get
            {
                return LanID.Substring(LanID.IndexOf('\\') + 1);
            }
        }
        //public int CurrentSprint
        //{
        //    get
        //    {
        //        return Utilities.SprintCalculator.GetCurrentSprint;
        //    }
        //}
        public int CurrentSprint { get; set; }
        public IEnumerable<int> LastThreeSprints { get; set; }
        public IEnumerable<Repository.Project> Projects { get; set; }
        public bool IsAdmin { get; set; }
        public bool isValid { get; set; }
        //public IEnumerable<int> LastThreeSprints
        //{
        //    get
        //    {
        //        return Utilities.SprintCalculator.GetTotalSprintsTillDate(DateTime.Now);
        //    }
        //}


    }
}