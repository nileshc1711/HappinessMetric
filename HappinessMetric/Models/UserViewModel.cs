using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Models
{
    public class UserViewModel
    {
        public string LanID { get; set; }
        public bool hasUserSubmittedForCurrentSprint { get; set; }
        public string UserName
        {
            get
            {
                return LanID.Substring(LanID.IndexOf('\\') + 1);
            }
        }
        public int CurrentSprint
        {
            get
            {
                return Utilities.SprintCalculator.GetSprintFromDate(DateTime.Now);
            }
        }

        public IEnumerable<int> LastThreeSprints
        {
            get
            {
                return Utilities.SprintCalculator.GetTotalSprintsTillDate(DateTime.Now);
            }
        }
    }
}