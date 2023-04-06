using DTOs;
using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class MessagePresenter : AbstractPresenter
    {

        public override ViewData ViewData 
        { 
            get
            {
                List<string> lines = new List<string>(1);
                lines.Add("\n" + ((MessageDTO)DataToPresent).Message);
                return new CommandLineViewData(lines);
            }
        }
    }
}
