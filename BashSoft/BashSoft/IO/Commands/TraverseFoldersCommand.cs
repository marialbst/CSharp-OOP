namespace BashSoft.IO.Commands
{
    using Exceptions;
    using StaticData;
    using Judge;
    using Repository;

    public class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length > 2)
            {
                throw new InvalidCommandException(this.Input);
                
            }
            
            if (this.Data.Length == 2)
            {
                int depth;
                if (int.TryParse(this.Data[1], out depth))
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
        }
    }
}
