using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using EkkaWebAutoTest.Pages.ProductPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Tests
{
    public class CartTests
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
            _loginPage = new LoginPage(_driver);
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
        public void Cart_Without_Login()
        {
            _homePage.Open();
            _homePage.ClickOnCart();
            _homePage.AssertOnLoginPage();
        }

        [Test]
        public void Cart_Empty()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account2.email, AccountStore.Account2.password);
            _homePage.ClickOnCart();
        }

        [Test]
        public void AddProduct_Without_Login()
        {
            _homePage.Open();
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.AssertOnLoginPage();
        }
    }
}
