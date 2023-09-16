using System;
using UseCase;
namespace Presenters
{

    [Serializable]
    public class LoanViewData : IViewData
    {
        public int ID { get; set; }
        public string Member { get; set; }
        public string Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfRenewals { get; set; }

        public LoanViewData(int id, string m, string b, DateTime loanDate, DateTime dueDate, int numRenewals)
        {
            ID = id;
            Member = m;
            Book = b;
            LoanDate = loanDate;
            DueDate = dueDate;
            
            NumberOfRenewals = numRenewals;
        }
    }
}
