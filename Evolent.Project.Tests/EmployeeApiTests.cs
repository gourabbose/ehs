using Evolent.Project.Api.Controllers;
using Evolent.Project.Managers;
using Evolent.Project.Managers.Interfaces;
using Evolent.Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Project.Tests
{
    [TestClass]
    public class EmployeeApiTests
    {
        EmployeeController controller { get; set; }
        Mock<IEmployeeManager> employeeManagerMock;

        [TestInitialize]
        public void Init()
        {
            this.employeeManagerMock = new Mock<IEmployeeManager>();
            this.controller = new EmployeeController(this.employeeManagerMock.Object);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(9)]
        public async Task GetEmployeeByIdTest(int id)
        {
            var anyException = false;
            try
            {
                this.employeeManagerMock
                    .Setup(m => m.GetEmployeeById(It.IsAny<int>()))
                    .Returns((int value) => { return Task.FromResult(new Employee { Id = value }); });
                var emp = await controller.Get(id);
                Assert.AreEqual(id, emp.Id);
            }
            catch(Exception ex)
            {
                anyException = true;
            }
            Assert.IsFalse(anyException);
        }
    }
}
