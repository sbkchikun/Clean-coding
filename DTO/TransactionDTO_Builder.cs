using System;

namespace DTOs
   
{
    public class TransactionDTO_Builder
    {
        private string transactionType;
        private string employeeName;
        private int itemId;
        private double itemPrice;
        private string itemName;
        
        private int itemQTY;
        public TransactionDTO Build()
        {
            return
                new TransactionDTO(transactionType,itemName,itemId, itemPrice, itemQTY,employeeName,DateTime.Today);
        }

        public TransactionDTO_Builder WithitemName(string itemName)
        {
            this.itemName = itemName;
            return this;
        }

        public TransactionDTO_Builder WithitemId(int itemId)
        {
            this.itemId = itemId;
            return this;
        }
        public TransactionDTO_Builder WithtransactionType(string transactionType)
        {
            this.transactionType = transactionType;
            return this;
        }
        public TransactionDTO_Builder WithemployeeName(string employeeName)
        {
            this.employeeName = employeeName;
            return this;
        }
        public TransactionDTO_Builder WithitemPrice(double itemPrice)
        {
            this.itemPrice = itemPrice;
            return this;
        }
        public TransactionDTO_Builder WithitemQTY(int itemQTY)
        {
            this.itemQTY = itemQTY;
            return this;
        }
        
    }
}
