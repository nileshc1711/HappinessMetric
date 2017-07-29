using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessMetric.Utilities
{
    public static class SprintCalculator
    {

        private static int StartSprint = 54, CurrentSprint = 54;
        private static DateTime SprintStartDate = new DateTime(2017, 6, 26).Date;
        private const int SprintCompletionDays = 14;

        static SprintCalculator()
        {
            var sprintPassed = GetNumberOfSprints(DateTime.Now);
            CurrentSprint += sprintPassed;
        }

        public static int GetCurrentSprint
        {
            get
            {
                return CurrentSprint;
            }
        }

        public static IEnumerable<int> GetTotalSprintsTillDate(DateTime date)
        {

            if (date > SprintStartDate)
            {

                var sprintPassed = GetNumberOfSprints(date);
                List<int> list = new List<int>();
                list.Add(StartSprint);

                for (int i = 1; i <= sprintPassed; i++)
                {
                    list.Add(list[i - 1] + 1);

                }

                return list.OrderByDescending(x => x).Take(3);
                //return arry;
            }
            return new List<int> { };
        }

        private static int GetNumberOfSprints(DateTime date)
        {
            if (date > SprintStartDate)
            {
                var result = date.Subtract(SprintStartDate);
                var daysPassed = result.Days;
                var sprintPassed = daysPassed / 14;
                return sprintPassed;
            }
            return -1;
        }
    }

}