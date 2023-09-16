
using System;

namespace DTOs
{

    [Serializable]
    public class LoanViewDTO : IDto
    {
        public int ID { get; }
        public string Member { get; }
        public string Book { get; }
        public string LoanDate { get; }
        public string DueDate { get; }

        public int NumberOfRenewals { get;}

        public LoanViewDTO(int id, string member , string book, string loanDate, string dueDate, int numberofRenewals)
        {
            this.ID = id;
            this.Member = member;
            this.Book = book;
            this.LoanDate = loanDate;
            this.DueDate = dueDate;

            this.NumberOfRenewals = numberofRenewals;
        }
    }
}
