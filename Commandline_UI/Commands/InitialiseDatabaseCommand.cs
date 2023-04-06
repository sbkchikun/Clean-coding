using Controllers;
using CommandLineUI.Presenters;
using System;

namespace CommandLineUI.Commands
{
    class InitialiseDatabaseCommand : Command
    {

        public InitialiseDatabaseCommand()
        {
            
        }

        public void Execute()
        {
            Console.WriteLine("amwork");
            InitialiseDatabaseController controller =
                new InitialiseDatabaseController(
                        new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
