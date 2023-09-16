using System.Collections.Generic;
using UseCase;
using DTOs;


namespace Windows.Presenters
{
    class CurrentLoansViewData : IViewData
    {
        public List<LoanViewDTO> ViewData { get; }
        public int Count { get; }

        public CurrentLoansViewData(List<LoanViewDTO> viewData, int count)
        {
            ViewData = viewData;
            Count = count;
        }
    }
}
