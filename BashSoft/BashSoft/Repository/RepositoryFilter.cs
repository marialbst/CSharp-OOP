namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using StaticData;

    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5,studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            int countedForPrinted = 0;
            foreach (var userNamePoints in wantedData)
            {
                if (countedForPrinted == studentsToTake)
                {
                    break;
                }

                double averageScore = userNamePoints.Value.Average();
                double percentageOfFullfilment = averageScore/100;
                double mark = percentageOfFullfilment*4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userNamePoints);
                    countedForPrinted++;
                }
            }

        }
    }
}
