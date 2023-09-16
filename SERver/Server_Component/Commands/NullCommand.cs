using Presenters;
using ServerSide;
using System.Collections.Generic;

namespace CommandLineUI.Commands
{
    class NullCommand : Command
    {

        public NullCommand()
        {
        }

        public async Task<CommandLineViewData> Execute()
        {
            ConsoleWriter.WriteStrings(
                new List<string>()
                    {"Menu choice not recognised"});
            return null;
        }
    }
}
