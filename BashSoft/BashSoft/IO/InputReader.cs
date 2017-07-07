namespace BashSoft.IO
{
    using StaticData;
    using System;

    public class InputReader
    {
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        private const string endCommand = "quit";
        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
