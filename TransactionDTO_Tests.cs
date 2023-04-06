using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DTOs;

namespace AssignmentTests
{
    
    [TestClass]
    public class TransactionDTOTests
    {
        [TestMethod]
        public void NewTransactionDTOHasCorrectType()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                .WithtransactionType("TestType").WithitemId(13).WithitemName ("TestItem").WithitemPrice (13.56).WithitemQTY(9) .WithemployeeName("John").Build();
            Assert.AreEqual("TestType", transaction.TransactionType);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectItemID()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                   .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            
            Assert.AreEqual(13, transaction.ItemId);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectItemName()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                      .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            Assert.AreEqual("TestItem", transaction.ItemName);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectItemCost()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                      .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            Assert.AreEqual(13.56, transaction.itemPrice);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectQuantity()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                      .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            Assert.AreEqual(9, transaction.itemQTY);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectEmployeeName()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                         .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            Assert.AreEqual("John", transaction.EmployeeName);
        }
        [TestMethod]
        public void NewTransactionDTOHasCorrectDateAdded()
        {
            TransactionDTO transaction = new TransactionDTO_Builder()
                      .WithtransactionType("TestType").WithitemId(13).WithitemName("TestItem").WithitemPrice(13.56).WithitemQTY(9).WithemployeeName("John").Build();
            

            Assert.AreEqual(DateTime.Today, transaction.TransactionTime);
        }
        

        

    }
}