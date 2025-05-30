using EkkaWebAutoTest.Pages.HomePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Tests
{
    public class ProductSearchTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _homePage = new HomePage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void SearchProduct_Success()
        {
            _homePage.Open();
            _homePage.SearchProduct("bag");
        }

        [Test]
        public void SearchProduct_NotFound()
        {
            _homePage.Open();
            _homePage.SearchProduct("glove");

        }

        [Test]
        public void SearchProduct_EmptyField()
        {
            _homePage.Open();
            _homePage.SearchProduct(string.Empty);
        }
    }
}
