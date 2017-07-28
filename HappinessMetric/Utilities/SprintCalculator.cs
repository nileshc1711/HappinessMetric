using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Utilities
{
    public static class SprintCalculator
    {

        private static int CurrentSprint = 56;
        private static DateTime SprintStartDate = new DateTime(2017, 7, 24).Date;
        private const int SprintCompletionDays = 14;
        

        public static int GetSprintFromDate(DateTime date)
        {
            if (date > SprintStartDate)
            {
                var result = date.Subtract(SprintStartDate);
                var daysPassed = result.Days;
                var sprintPassed = daysPassed / 14;
                return CurrentSprint += sprintPassed;

            }
            return -1;
        }
    }

}