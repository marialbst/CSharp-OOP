namespace BashSoft.Judge
{
    using System;
    using System.IO;
    using IO;
    using StaticData;

    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");

            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);
                bool hasMismatch;

                string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);
                PrintOutput(mismatches, hasMismatch, mismatchPath);

                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException e)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);                
            } 
            
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
                return;
            }
            
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
            
        }

        private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = String.Empty;

            int minOutputLength = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLength = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLength];

            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            
            for (int index = 0; index < minOutputLength; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];
                
                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format($"Mismatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"");
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }
            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf("\\");
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatch.txt";
            return finalPath;
        }
    }
}
