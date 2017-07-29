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
        public int CurrentSprint
        {
            get
            {
                return Utilities.SprintCalculator.GetCurrentSprint;
            }
        }

        public IEnumerable<int> LastThreeSprints
        {
            get
            {
                return Utilities.SprintCalculator.GetTotalSprintsTillDate(DateTime.Now);
            }
        }
        public IEnumerable<string> Projects {
            get
            {
                return new string[] { "MedClarity" };
            }
        }
    }
}