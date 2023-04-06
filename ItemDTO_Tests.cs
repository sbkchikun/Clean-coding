using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection.Metadata;
using DTOs;
using DatabaseGateway;
namespace AssignmentTests
{
    [TestClass]
    public class ItemDTO_Tests
    {
        [TestMethod]
        public void TestBuildNewItemHasCorrectId()
        {
            ItemDTO item = new ItemDTO_Builder()
                                .WithitemName("Pencil")
                                .WithId(1)
                                .WithQTY(10)
                                .Build(); 
            Assert.AreEqual(1, item.Id);
        }

        [TestMethod]
        public void TestNewItemHasCorrectName()
        {
            ItemDTO item = new ItemDTO_Builder()
                                .WithitemName("Pencil")
                                .WithId(1)
                                .WithQTY(10)
                                .Build();
            Assert.AreEqual("Pencil", item.ItemName);
        }

        [TestMethod]
        public void TestNewItemHasCorrectQuantity()
        {
            
            ItemDTO item = new ItemDTO_Builder()
                                .WithitemName("Pencil")
                                .WithId(1)
                                .WithQTY(3)
                                .Build();
            Assert.AreEqual(3, item.QTY);
            
        }

        [TestMethod]
        public void TestNewItemHasCorrectCreationDate()
        {
            ItemDTO item = new ItemDTO_Builder()
                                .WithitemName("Pencil")
                                .WithId(1)
                                .WithQTY(10)
                                .Build();
            DateTime now = DateTime.Today;
            Assert.AreEqual(now, item.DateCreated);
            
        }

        

        
        
       
        
        
        
        
        
    }
}
