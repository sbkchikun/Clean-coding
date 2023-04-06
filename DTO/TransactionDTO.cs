using System;

namespace DTOs
{
    [Serializable]
    public class TransactionDTO : DTO
    {
        public string TransactionType { get; }
        public string EmployeeName { get; }
        public int EmployeeId { get; }
        public int ItemId { get; }
        public double itemPrice { get; }
        public string ItemName { get; }
        public DateTime TransactionTime { get; }
        public int itemQTY { get; }
        public TransactionDTO(string transactionType, string itemName,int itemId,double itemPrice , int itemQTY, string employeeName, DateTime transactionTime)
        {
            this.ItemId = itemId;
            this.ItemName = itemName;
            this.TransactionType = transactionType;
            this.EmployeeName = employeeName;
            this.itemPrice = itemPrice;
            this.itemQTY = itemQTY;
            this.TransactionTime = transactionTime;
            
        }
    }
}
