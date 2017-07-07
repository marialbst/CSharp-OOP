namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using StaticData;

    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison,int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(wantedData.OrderBy(x => x.Value.Sum())
                                        .Take(studentsToTake)
                                        .ToDictionary(pair=>pair.Key,pair =>pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum())
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
        
        private void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }

        private Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted, int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> Comparison)
        {
            int valuesTaken = 0;
            Dictionary<string,List<int>> studentsSorted = new Dictionary<string, List<int>>();
            KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
            bool isSorted = false;

            while (valuesTaken < takeCount)
            {
                isSorted = true;

                foreach (var studentWithScore in studentsWanted)
                {
                    if (!String.IsNullOrEmpty(nextInOrder.Key))
                    {
                        int comparisonResult = Comparison(studentWithScore, nextInOrder);
                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentWithScore.Key))
                        {
                            nextInOrder = studentWithScore;
                            //valuesTaken++;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(studentWithScore.Key))
                        {
                            nextInOrder = studentWithScore;
                            isSorted = false;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    valuesTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
            }

            return studentsSorted;
        }

        private int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = 0;
            foreach (var i in firstValue.Value)
            {
                totalOfFirstMarks += i;
            }
            int totalOfSecondMarks = 0;
            foreach (var i in secondValue.Value)
            {
                totalOfSecondMarks += i;
            }

            return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        }

        private int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = 0;
            foreach (var i in firstValue.Value)
            {
                totalOfFirstMarks += i;
            }
            int totalOfSecondMarks = 0;
            foreach (var i in secondValue.Value)
            {
                totalOfSecondMarks += i;
            }
            return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        }
    }
}
