using Evolent.Project.DataAccess;
using Evolent.Project.DataAccess.Interfaces;
using Evolent.Project.Models;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeeRepositoryTests
    {
        IEmployeeRepository repository;
        Mock<EvolentContext> contextMock;

        [TestInitialize]
        public void Init()
        {
            this.contextMock = new Mock<EvolentContext>();
            repository = new EmployeeRepository(this.contextMock.Object);
        }

        [TestMethod]
        public async Task CreateItemTest()
        {
            var anyException = false;

            try
            {
                await repository.CreateAsync(new Employee
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
