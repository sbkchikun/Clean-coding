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
    public class GatewayFacade_Tests_For_Employees
    {
        [TestMethod]
        public void DatabaseInitialiserCreatesEmptyEmployeesTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            Assert.AreEqual(0, GatewayFacade.GetAllEmployees().Count);
            
        }
        [TestMethod]
        public void AddEmployeeAddsEmployeeToTable()
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("john").Build());
            Assert.AreEqual(1, GatewayFacade.GetAllEmployees().Count);


        }
        [TestMethod]
        public void AddEmployeeAddsCorrectEmployeeToTable() 
        {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("john").Build()) ;
            Assert.AreEqual("john", GatewayFacade.FindEmployee("john").EmployeeName);
            
                
        }
        [TestMethod]
        public void CorrectEmployeeCountInEmployeeTable() {
            
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("john").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("jane").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("doe").Build());
            Assert.AreEqual(3, GatewayFacade.GetAllEmployees().Count);
        }
        [TestMethod]
        public void FindEmployeeFindsExistingEmployee() 
        {
            
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("john").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("jane").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("doe").Build());
            Assert.AreEqual("doe", GatewayFacade.FindEmployee("doe").EmployeeName);

        }
        [TestMethod]
        public void FindEmployeeReturnsNullWhenEmployeeNotFound() {
            DatabaseGatewayFacade GatewayFacade = new DatabaseGatewayFacade();
            GatewayFacade.InitialiseDatabase();
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("john").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("jane").Build());
            GatewayFacade.AddEmployee(new EmployeeDTO_Builder().WithemployeeName("doe").Build());
            Assert.AreEqual(null, GatewayFacade.FindEmployee("janedoe"));
            
        }
    }
}