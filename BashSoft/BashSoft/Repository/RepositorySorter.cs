namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using StaticData;

    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> wantedData, string comparison,int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(wantedData.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair=>pair.Key,pair =>pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(wantedData.OrderByDescending(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
        
        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}
