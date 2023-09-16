/*using DTOs;
using System;

namespace Presenters.Visitor
{

    class VisitableLoan : Visitable
    {
        private LoanViewDTO loan;
        public int ID 
        {
            get
            {
                return loan.ID;
            }
        }
        public string Member
        {
            get
            {
                return loan.Member;
            }
        }
        public string Book
        {
            get
            {
                return loan.Book;
            }
        }
        *//*public DateTime DueDate
        {
            get
            {
                return loan.DueDate;
            }
        }
        public DateTime LoanDate
        {
            get
            {
                return loan.LoanDate;
            }
        }*//*
        public int NumberOfRenewals
        {
            get
            {
                return loan.NumberOfRenewals;
            }
        }
         

        public VisitableLoan(LoanViewDTO loan)
        {
            this.loan = loan;
        }

        public void AcceptVisitFrom(Visitor v)
        {
            v.VisitLoan(this);
        }
    }
}
*/