using CommandLineUI.Commands;
using CommandLineUI.Menu;
using System;

namespace CommandLineUI
{
    
    public class CommandLineUserInterface
    {


        public CommandLineUserInterface()
        {
        }

        public void Start()
        {
            CommandFactory factory = new CommandFactory();
            try
            {
                factory
                    .CreateCommand(RequestUseCase.INITIALISE_DATABASE)
                    .Execute();

                MenuFactory.INSTANCE.Create().Print("");
                int choice = GetMenuChoice();

                while (choice != RequestUseCase.EXIT)
                {
                    factory
                        .CreateCommand(choice)
                        .Execute();

                    MenuFactory.INSTANCE.Create().Print("");
                        choice = GetMenuChoice();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message);
            }
        }

        private int GetMenuChoice()
        {
            int option = ConsoleReader.ReadInt("\nOption");
            while (option < 1 || option > 8)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ConsoleReader.ReadInt("\nOption");
            }
            return option;
        }
    }
}
