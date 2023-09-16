using System.Collections.Generic;
using UseCase;
using DTOs;
namespace Presenters
{
    class WPFViewData<T> : IViewData where T : IDto
    {
        public List<T> ViewData { get; }
        
        public WPFViewData(List<T> viewData)
        {
            ViewData = viewData;
            
        }
    }
}
