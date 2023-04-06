using DTOs;
using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class PersonalUsageReportPresenter : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                List<TransactionDTO> Transactions = ((TransactionDTO_List)DataToPresent).List;
                if (Transactions != null)
                {
                    List<TransactionDTO> TransactionsForPersonalUsageReport = new List<TransactionDTO>();
                    foreach (TransactionDTO t in Transactions)
                        if (t.TransactionType.Equals("Quantity Removed")) { TransactionsForPersonalUsageReport.Add(t); }
                    List<string> lines = new List<string>(Transactions.Count + 2);
                    lines.Add(string.Format("\nPersonal Usage Report for {0}", Transactions[0].EmployeeName));
                    lines.Add(string.Format(
                    "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                    "Date Taken",
                    "ID",
                    "Name",
                    "Quantity Removed"));
                    Transactions.ForEach(t => lines.Add(DisplayItem(t)));
                    return new CommandLineViewData(lines);
                }
                List<string> ErrorLine = new List<string>(1);
                ErrorLine.Add(string.Format("ERROR: Employee not found"));
                return new CommandLineViewData(ErrorLine);
            }
            }
            private string DisplayItem(TransactionDTO t)
        {

            
                return string.Format(
                        "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                        t.TransactionTime,
                        t.ItemId,
                        t.ItemName,
                        t.itemQTY);


        }
        
    }
}
