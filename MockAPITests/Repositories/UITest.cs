using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MockAPITests.Repositories
{
    [TestClass()]
    public class UITest
    {
        private static readonly string DriverDirectory = "C:\\BrowserTest Drivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new EdgeDriver(DriverDirectory);
            //_driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver?.Dispose();
        }

        [TestMethod()]
        public void GetAllUITest()
        {
            string url = "http://127.0.0.1:5500/index.html";
            _driver.Navigate().GoToUrl(url);

            IWebElement GetAll = _driver.FindElement(By.Id("app"));
            GetAll.Click();

            WebDriverWait driverWait = new(_driver, TimeSpan.FromSeconds(10));
            IWebElement GetAllList = _driver.FindElement(By.Id("app"));
            IWebElement GetAllListElements = driverWait.Until(d => d.FindElement(By.ClassName("header")));
            int countInList = _driver.FindElements(By.ClassName("header")).Count();
            Assert.AreEqual(1, countInList, "Count in list was not Correct, i got: " + countInList);

            var FirstElement = _driver.FindElements(By.ClassName("header")).FirstOrDefault()!;
            string TextInFirstElement = FirstElement.Text;
            Assert.AreEqual("<Weather Wear About Us>", TextInFirstElement, "First Text Element Not Found");

        }
    }
}
