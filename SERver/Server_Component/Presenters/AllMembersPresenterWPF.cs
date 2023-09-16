using DTOs;
using System.Collections.Generic;
using UseCase;

namespace Presenters
{
    class AllMembersPresenterWPF : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<MemberDTO> members = ((MemberDTO_List)DataToPresent).List;
                List<MemberDTO> MemberDataList = new List<MemberDTO>();
                foreach (var member in members)
                {
                    MemberDTO MemberData = new MemberDTO(member.ID, member.Name);


                    MemberDataList.Add(MemberData);
                }
                

                return new WPFViewData<MemberDTO>(MemberDataList);
            }
        }

        
    }
}
