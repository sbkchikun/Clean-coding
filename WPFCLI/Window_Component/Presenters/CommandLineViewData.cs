using System.Collections.Generic;
using UseCase;

namespace Windows.Presenters
{
    class CommandLineViewData : IViewData
    {
        public List<string> ViewData { get; }

        public CommandLineViewData(List<string> viewData)
        {
            ViewData = viewData;
        }
    }
}
