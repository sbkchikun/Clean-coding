using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DTOs;

namespace AssignmentTests
{
    [TestClass]
    public class EmployeeTests
    { [TestMethod]
    public void EmployeeNameIsCorrect()
        {
           EmployeeDTO employee = new EmployeeDTO_Builder()
                    .WithemployeeName("Test")
                    .Build();
            Assert.AreEqual("Test", employee.EmployeeName);

        }
    }
}
