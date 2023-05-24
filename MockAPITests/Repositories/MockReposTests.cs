using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using MockAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAPI.Repositories.Tests
{
    [TestClass()]
    public class MockReposTests
    {
        MockRepos? repository;

        [TestMethod()]
        public void GetAllTest()
        {
            repository = new MockRepos();
            var ListOfMockData = repository.GetAll();

            int countInList = ListOfMockData.Count();
            Assert.IsNotNull(ListOfMockData);
            Assert.AreEqual(4, countInList);
        }
    }
}