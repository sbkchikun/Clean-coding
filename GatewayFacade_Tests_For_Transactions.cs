using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DatabaseGateway;
using UseCases;
using DTOs;
namespace AssignmentTests
{
    [TestClass]
    public class GatewayFacade_Tests_For_Transactions
    {
        [TestMethod]
        public void DatabaseInitialiserCreatesEmptyTransactionsTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            Assert.AreEqual(0, GatewayFacade.GetAllTransactions().Count);
        }
        [TestMethod]
        public void AddTransactionLogAddsTransactionToTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual(1, GatewayFacade.GetAllTransactions().Count);
        }
        [TestMethod]
        public void AddTransactionLogAddsCorrectTransactionToTable() 
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual("a", GatewayFacade.GetAllTransactions()[0].ItemName);
            
                
        }
        [TestMethod]
        public void CorrectTransactionCountInTransactionsTable() {
            
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual(3, GatewayFacade.GetAllTransactions().Count);
        }
        [TestMethod]
        public void FindTransactionsByEmployeeFindsTransactions() 
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual(3, GatewayFacade.FindTransactionsByEmployee("Graham").Count);

        }
        
            
            
        
        [TestMethod]
        public void TestItemNameStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual("a", GatewayFacade.GetAllTransactions()[0].ItemName);
        }
        [TestMethod]
        public void TestItemIDStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual(2, GatewayFacade.GetAllTransactions()[0].ItemId);
        }
        [TestMethod]
        public void TestItemQTYStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual(1, GatewayFacade.GetAllTransactions()[0].itemQTY);
        }
        [TestMethod]
        public void TestEmployeeNameStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual("Graham", GatewayFacade.GetAllTransactions()[0].EmployeeName);
        }
        [TestMethod]
        public void TestItemCostStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            
            Math.Round(GatewayFacade.GetAllTransactions()[0].itemPrice, 1);
            Assert.AreEqual(3.2, Math.Round(GatewayFacade.GetAllTransactions()[0].itemPrice, 1));
        }
        [TestMethod]
        public void TestTransactionTypeStoredCorrectlyInTransactionsTable()
        {

            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Graham")
                    .Build());
            GatewayFacade.AddEmployee(
                new EmployeeDTO_Builder()
                    .WithemployeeName("Jerry")
                    .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("a")
                                   .WithitemId(2)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("b")
                                   .WithitemId(1)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(4)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Graham")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("d")
                                   .WithitemId(5)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            GatewayFacade.AddTransactionLog(new TransactionDTO_Builder()
                                   .WithitemName("c")
                                   .WithitemId(6)
                                   .WithitemQTY(1)
                                   .WithemployeeName("Jerry")
                                   .WithitemPrice(3.2)
                                   .WithtransactionType("Test")
                                   .Build());
            Assert.AreEqual("Test", GatewayFacade.GetAllTransactions()[0].TransactionType);
        }
        
    }
}