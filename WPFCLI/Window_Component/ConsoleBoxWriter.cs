using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Windows
{
    
        class ConsoleBoxWriter
        {
            public static void WriteStrings(List<string> lines, TextBox consoleBox)
            {if (consoleBox != null)
                {
                
                foreach (string line in lines)
                {
                    consoleBox.AppendText(line + "\n");
                }
                }
            }
        }
   
}
