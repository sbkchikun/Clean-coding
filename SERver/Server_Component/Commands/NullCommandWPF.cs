using Presenters;
using ServerSide;
using System.Collections.Generic;

namespace CommandLineUI.Commands
{
    class NullCommandWPF : CommandWPF
    {

        public NullCommandWPF()
        {
        }

        public async Task<string> Execute()
        {
            ConsoleWriter.WriteStrings(
                new List<string>()
                    {"Menu choice not recognised"});
            return null;
        }
    }
}
