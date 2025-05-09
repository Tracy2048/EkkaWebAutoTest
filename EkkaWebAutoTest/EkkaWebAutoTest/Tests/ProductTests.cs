using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkkaWebAutoTest.Pages.ProductPage;
using System.Xml.Linq;
using EkkaWebAutoTest.Constants;

namespace EkkaWebAutoTest.Tests
{
    public class ProductTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private ProductPage _productPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _homePage = new HomePage(_driver);
            _productPage = new ProductPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void ViewProduct_Without_Login()
        {
            _homePage.Open();

            IWebElement product = _homePage.ProductRandom;
            string title = product.GetAttribute("title");

            _homePage.ClickOnProduct(product);
            _productPage.AssertProductName(title);
        }

        [Test]
        public void ViewProduct_After_Login()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage.Open();
            _loginPage.Login("hangt7708@gmail.com", "User1234@");

            IWebElement product = _homePage.ProductRandom;
            string title = product.GetAttribute("title");

            _homePage.ClickOnProduct(product);
            _productPage.AssertProductName(title);
        }
    }
}
