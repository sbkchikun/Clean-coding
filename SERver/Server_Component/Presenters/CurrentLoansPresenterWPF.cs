using DTOs;
using Entities;
using Presenters.Visitor;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UseCase;

namespace Presenters
{
    class CurrentLoansPresenterWPF : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<LoanDTO> loans = ((LoanDTO_List)DataToPresent).List;
                List<LoanViewDTO> transfloans = new List<LoanViewDTO>();
                LoanPrinter printer = new LoanPrinter();
                MembersWithLoansCounter counter = new MembersWithLoansCounter();
                GetVisitableLoans(loans).ForEach(
                    loan =>
                {
                    loan.AcceptVisitFrom(printer);
                    loan.AcceptVisitFrom(counter);
                });
                foreach (var loan in loans)
                {
                    LoanViewDTO LoanData = new LoanViewDTO(loan.ID, loan.Member.Name, loan.Member.Name,loan.LoanDate.ToString("dd/MM/yyyy"), loan.DueDate.ToString("dd/MM/yyyy"), loan.NumberOfRenewals);


                    transfloans.Add(LoanData);
                }
                return /*new WPFViewData<LoanViewDTO>(transfloans)*/ new CurrentLoansViewData(printer.Visitableloans, counter.NumberOfMembersWithLoans);
            }
        }

        private List<VisitableLoan> GetVisitableLoans(List<LoanDTO> loans)
        {
            List<VisitableLoan> list = new List<VisitableLoan>(loans.Count);

            loans.ForEach(loan => list.Add(new VisitableLoan(loan)));

            return list;
        }
    }
}
