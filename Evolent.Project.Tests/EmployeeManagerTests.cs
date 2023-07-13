using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Managers;
using Evolent.Project.Managers.Interfaces;
using Evolent.Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Evolent.Project.Tests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        IEmployeeManager manager;
        Mock<IEmployeeRepository> employeeRepositoryMock;
        Mock<IAddressRepository> addressRepositoryMock;

        [TestInitialize]
        public void Init()
        {
            this.employeeRepositoryMock = new Mock<IEmployeeRepository>();
            this.addressRepositoryMock = new Mock<IAddressRepository>();
            this.manager = new EmployeeManager(employeeRepositoryMock.Object, addressRepositoryMock.Object);
        }

        [TestMethod]
        public async Task CreateEmployeeTest()
        {
            var anyException = false;
            
            try
            {
                await manager.CreateEmployee(new Employee
                {
                    FirstName = "Gourab",
                    LastName = "Bose",
                    Age = 32,
                    EmailAddress = "gourab@yopmail.com",
                });
            }
            catch
            {
                anyException = true;
            }
            Assert.IsFalse(anyException);
        }
    }
}
