using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class CommandLineViewData : ViewData
    {
        public List<string> ViewData { get; }

        public CommandLineViewData(List<string> viewData)
        {
            ViewData = viewData;
        }
    }
}
