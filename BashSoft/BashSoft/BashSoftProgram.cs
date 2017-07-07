namespace BashSoft
{
    using IO;
    using Judge;
    using Repository;

    class BashSoftProgram
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
