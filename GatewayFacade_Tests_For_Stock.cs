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
    public class GatewayFacade_Tests_For_Stock
    {
        [TestMethod]
        public void DatabaseInitialiserCreatesEmptyStockTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            Assert.AreEqual(0, GatewayFacade.GetAllItems().Count);
        }
        [TestMethod]
        public void AddItemAddsItemToTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            Assert.AreEqual(1, GatewayFacade.GetAllItems().Count);
        }
        [TestMethod]
        public void AddItemAddsCorrectItemToTable() 
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            Assert.AreEqual("a", GatewayFacade.FindItem(2).ItemName);
            
                
        }
        [TestMethod]
        public void CorrectItemCountInStockTable() {
            
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("b")
                                   .WithId(1)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("c")
                                   .WithId(3)
                                   .WithQTY(1)
                                   .Build());
            Assert.AreEqual(3, GatewayFacade.GetAllItems().Count);
        }
        [TestMethod]
        public void FindItemFindsExistingItem() 
        {
            
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("b")
                                   .WithId(1)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("c")
                                   .WithId(3)
                                   .WithQTY(1)
                                   .Build());
            Assert.AreEqual("c", GatewayFacade.FindItem(3).ItemName);

        }
        [TestMethod]
        public void FindItemReturnsNullWhenItemNotFound() {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("b")
                                   .WithId(1)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("c")
                                   .WithId(3)
                                   .WithQTY(1)
                                   .Build());
            Assert.AreEqual(null, GatewayFacade.FindItem(5));
            
        }
        [TestMethod]
        public void TestInvalidValuesForAddItemProducesCorrectErrorMessage()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            try
            {
                GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("")
                                   .WithId(0)
                                   .WithQTY(0)
                                   .Build());

            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: ID below 1; Quantity below 1; Item name is empty; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }

        }
       

        [TestMethod]
        public void AddQuantityGivesCorrectQuantityInItem()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            GatewayFacade.AddQuantity(2, 1);
            Assert.AreEqual(2, GatewayFacade.FindItem(2).QTY);
        }
        [TestMethod]
        public void AddQuantityGivesCorrectErrorMessageForInvalidValue()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(1)
                                   .Build());
            

            try
            {
                GatewayFacade.AddQuantity(2, -1);
                

            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Quantity being added is below 0";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
        [TestMethod]
        public void RemoveQuantityGivesCorrectQuantityInItem()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(4)
                                   .Build());
            GatewayFacade.RemoveQuantity(2, 1);
            Assert.AreEqual(3, GatewayFacade.FindItem(2).QTY);
            
        }
        [TestMethod]
        public void RemoveQuantityGivesCorrectErrorMessageForValueBelow0()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(4)
                                   .Build());

            try
            {
                
                GatewayFacade.RemoveQuantity(2, -1);
            }
            catch (Exception e)
            {
                string expectedErrorMsg = "ERROR: Quantity being removed is below 0";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
        [TestMethod]
        public void RemoveQuantityGivesCorrectErrorMessageForValueTooHigh()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddItem(new ItemDTO_Builder()
                                   .WithitemName("a")
                                   .WithId(2)
                                   .WithQTY(4)
                                   .Build());

            try
            {

                GatewayFacade.RemoveQuantity(2, 8);
            }
            catch (Exception e)
            {
                string expectedErrorMsg = "ERROR: Quantity too many";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
    }
}