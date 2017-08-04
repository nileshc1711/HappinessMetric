using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Utilities
{
    public static class SprintCalculator
    {
        public static int GetSprintNo(string username)
        {
            var sprintDetails = Repository.DatabaseHelper.GetSprintNo(username);
            var sprintNo = sprintDetails.ps_sprintNo;
            var sprintStartDate = sprintDetails.ps_sprintStartDate;
            var sprintLength = sprintDetails.ps_sprintDays;
            var currentDate = DateTime.Today;
            var CurrentSprintNo = ((currentDate.Subtract(sprintStartDate).Days) / sprintLength)+sprintNo;
            return CurrentSprintNo;
        }

        public static IEnumerable<int> GetLast3SprintNo(int currentSprintNo)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(currentSprintNo);
                currentSprintNo = currentSprintNo - 1;

            }
            return list;
        }
     
    }

}