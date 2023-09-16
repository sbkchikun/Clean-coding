using System;
using System.Collections.Generic;

namespace ServerSide
{
    class ConsoleWriter
    {
        public static void WriteStrings(List<string> lines)
        {
            lines.ForEach(Console.WriteLine);
        }
    }
}
