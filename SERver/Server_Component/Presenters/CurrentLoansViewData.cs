using DTOs;
using System.Collections.Generic;
using UseCase;

namespace Presenters
{
    class CurrentLoansViewData : IViewData
    {
        public List<LoanViewDTO> ViewData { get; }
        public int Count { get; }

        public CurrentLoansViewData(List<LoanViewDTO> viewData,int count)
        {
            ViewData = viewData;
            Count = count;
        }
    }
}
