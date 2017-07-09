namespace BashSoft.Repository
{
    using System;
    using System.Linq;
    using Exceptions;
    using Models;
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
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialisedException);
                
            }
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            this.courses = null;
            this.students = null;
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
               // @"([A-Z][A-Za-z\+#]*_[JFMASOND][a-z]{2}_201[4-7])\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d{2}|100)\b";
                Regex regex = new Regex(pattern);
                string[] inputAllLines = File.ReadAllLines(path);

                for (int line = 0; line < inputAllLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(inputAllLines[line]) && regex.IsMatch(inputAllLines[line]))
                    {
                        Match currentMatch = regex.Match(inputAllLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string studentName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(studentName))
                            {
                                this.students.Add(studentName, new Student(studentName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine(fe.Message + $" at line: {line}");
                        }
                    }
                    isDataInitialized = true;
                }

                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);

            if (this.courses.ContainsKey(courseName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                
            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if(this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentName))
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
                var kvPair = new KeyValuePair<string, double>(username, this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]);
                OutputWriter.PrintStudent(kvPair);
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (var entry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentsScoreFromCourse(courseName,entry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key,
                    x => x.Value.MarksByCourseName[courseName]);

                filter.FilterAndTake(marks, givenFilter,studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key,
                    x => x.Value.MarksByCourseName[courseName]);

                sorter.OrderAndTake(marks, comparison,studentsToTake.Value);
            }
        }
    }
}
