using System;
using System.Xml.Linq;

namespace Assignment
{
    public class TransactionLogEntry
    {
        public string TypeOfTransaction { get; }
        public int ItemID { get; }
        public string ItemName { get; }
        public double ItemPrice { get; }
        public int Quantity { get; }
        public string EmployeeName { get; }
        public DateTime DateAdded { get; }

        public TransactionLogEntry(string type, int itemID, string itemName, double itemPrice, int quantity, string employeeName, DateTime dateAdded)
        {
            string errorMsg = "";
            if(type == "Quantity Added" || type == "Item Added"|| type == "Quantity Removed" ) { this.TypeOfTransaction = type; }
            else { errorMsg += "Type must be a string; "; }
            if (itemID < 1)
            {
                errorMsg += "ID below 1; ";
            }

            if (quantity < 1)
            {
                errorMsg += "Quantity below 1; ";
            }

            if (itemName.Length == 0)
            {
                errorMsg += "Item name is empty; ";
            }

            if (errorMsg.Length > 0)
            {
                throw new Exception("ERROR: " + errorMsg);
            }
           
            this.ItemID = itemID;
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.Quantity = quantity;
            this.EmployeeName = employeeName;
            this.DateAdded = dateAdded;
        }
    }
}
