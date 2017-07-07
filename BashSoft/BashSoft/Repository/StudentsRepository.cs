namespace BashSoft.Repository
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using IO;
    using StaticData;

    public class StudentsRepository
    {
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        private bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
                return;
                
            }
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern =
                @"([A-Z][A-Za-z\+#]*_[JFMASOND][a-z]{2}_201[4-7])\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d{2}|100)\b";
                Regex regex = new Regex(pattern);
                string[] inputAllLines = File.ReadAllLines(path);

                for (int line = 0; line < inputAllLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(inputAllLines[line]) && regex.IsMatch(inputAllLines[line]))
                    {
                        Match currentMatch = regex.Match(inputAllLines[line]);
                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        int mark;
                        bool hasParsedMark = int.TryParse(currentMatch.Groups[3].Value, out mark);

                        if (hasParsedMark && mark >=0 && mark <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(course))
                            {
                                studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                            }

                            if (!studentsByCourse[course].ContainsKey(student))
                            {
                                studentsByCourse[course].Add(student, new List<int>());
                            }

                            studentsByCourse[course][student].Add(mark);
                        }
                    }
                    isDataInitialized = true;
                }

                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);

            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                
            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if(IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            return false;
        }

        public void GetStudentsScoreFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                var kvPair = new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]);
                OutputWriter.PrintStudent(kvPair);
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (var entry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(entry);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                filter.FilterAndTake(studentsByCourse[courseName],givenFilter,studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                sorter.OrderAndTake(studentsByCourse[courseName],comparison,studentsToTake.Value);
            }
        }
    }
}
