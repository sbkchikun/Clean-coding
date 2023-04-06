using DTOs;
using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class FinancialReportPresenter : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                List<TransactionDTO> Transactions = ((TransactionDTO_List)DataToPresent).List;
                List<TransactionDTO> TransactionsForFinancialReport = new List<TransactionDTO>();
                foreach (TransactionDTO t in Transactions)
                    if (t.TransactionType.Equals("Item Added")
                       || t.TransactionType.Equals("Quantity Added")) { TransactionsForFinancialReport.Add(t); }
                
                List<string> lines = new List<string>(Transactions.Count + 2);
                lines.Add("\nTransaction Log:");
                lines.Add(string.Format("\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));
                Transactions.ForEach (t => lines.Add(DisplayItem(t)));
                    return new CommandLineViewData(lines);
                }
            }
        private string DisplayItem(TransactionDTO t)
        {



            return string.Format("\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                t.TransactionTime.ToString("dd/MM/yyyy"),
                t.TransactionType,
                t.ItemId,
                t.ItemName,
                t.itemQTY,
                t.EmployeeName,
                t.TransactionType.Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}", t.itemPrice)); 
                

            
        }
    }
}
