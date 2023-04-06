using DTOs;
using System.Collections.Generic;
using UseCases;

namespace CommandLineUI.Presenters
{
    class TransactionLogPresenter : AbstractPresenter
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
                lines.Add("\nFinancial Report:");
                TransactionsForFinancialReport.ForEach(t => lines.Add(DisplayItem(t)));
                lines.Add(DisplayTotalCostOfAllItems(TransactionsForFinancialReport));
                    return new CommandLineViewData(lines);
                }
            }
            private string DisplayItem(TransactionDTO t)
        {double totalItemCost= TotalItemCost(t.itemPrice, t.itemQTY);
            return string.Format(
                "{0}: Total price of item: {1:C}",
                t.ItemName,
                totalItemCost
                );

            
        }
        private double TotalItemCost(double itemPrice, int itemQTY) { double totalItemCost = itemPrice * itemQTY;
            return totalItemCost;
        }
        private string DisplayTotalCostOfAllItems(List<TransactionDTO> transactions)
        {
            double TotalCostOfAllItems=0;
            foreach (TransactionDTO t in transactions) { double totalItemCost = TotalItemCost(t.itemPrice, t.itemQTY);
                TotalCostOfAllItems += totalItemCost;
            }
            return string.Format(
        "{0}: {1:C}", "Total price of all items", TotalCostOfAllItems);


        }
    }
}
