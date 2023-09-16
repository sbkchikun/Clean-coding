using System.Collections.Generic;
using UseCase;
using DTOs;
namespace Windows.Presenters
{
    class MemberViewData : IViewData
    {
        public List<MemberDTO> ViewData { get; }

        public MemberViewData(List<MemberDTO> viewData)
        {
            ViewData = viewData;
        }
    }
}
