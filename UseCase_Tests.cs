using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseGateway;
using System;
using CommandLineUI.Commands;
using CommandLineUI;
using UseCases;
using System.Collections.Generic;
using DTOs;
namespace AssignmentTests
{
    [TestClass]
    public class UseCase_Tests
    {
        [TestMethod]
        public void InitialiseDataInitialisesEmployees()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            new InitialiseData(GatewayFacade).Execute();
            Assert.AreEqual(3, GatewayFacade.GetAllEmployees().Count);

        }
        [TestMethod]
        public void InitialiseDataInitialisesStock()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            new InitialiseData(GatewayFacade).Execute();
            Assert.AreEqual(2, GatewayFacade.GetAllItems().Count);
        }
        [TestMethod]
        public void InitialiseDataInitialisesTransactions()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            new InitialiseData(GatewayFacade).Execute();
            Assert.AreEqual(4, GatewayFacade.GetAllTransactions().Count);

            
        }
       
    }
}


