using System.Collections.Generic;
using UseCase;
using DTOs;
namespace Presenters
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
