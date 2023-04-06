using System.Collections.Generic;
using System.Transactions;

namespace Assignment
{
    public class TransactionLogManager
    {
        private List<TransactionLogEntry> transactions;

        public TransactionLogManager()
        {
            this.transactions = new List<TransactionLogEntry>();
        }

        public void AddTransactionLog(TransactionLogEntry entry)
        {
            transactions.Add(entry);
        }

        public List<TransactionLogEntry> GetTransactionLog()
        {
            return transactions;
        }
        public TransactionLogEntry FindTransaction(int ItemID)
        {
            try
            {
                return transactions[ItemID];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
