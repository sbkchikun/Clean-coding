using DTOs;
using System.Collections.Generic;

namespace Windows.Commands
{
    class NullCommand : Command
    {

        public NullCommand()
        {
        }

        public RequestDTO Execute()
        {
            //ConsoleWriter.WriteStrings(
            //    new List<string>()

            //        {"Menu choice not recognised"});
            return null;
        }
    }
}
