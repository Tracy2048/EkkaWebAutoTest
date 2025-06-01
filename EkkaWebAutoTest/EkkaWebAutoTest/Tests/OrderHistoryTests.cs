using EkkaWebAutoTest.Pages.AccountPage;
using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkkaWebAutoTest.Constants;

namespace EkkaWebAutoTest.Tests
{
    public class OrderHistoryTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private AccountPage _accountPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _accountPage = new AccountPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void OrderHistory_Empty()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account2.email, AccountStore.Account2.password);
            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _homePage.AccountButton);
            _accountPage.ClickViewOrderHistoryButton();
            _accountPage.AssertOrderHistoryEmpty();
        }

        [Test]
        public void OrderHistory_HasOrders() 
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _homePage.AccountButton);
            _accountPage.ClickViewOrderHistoryButton();
        }

        [Test]
        public void OrderHistory_OrderDetails()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _homePage.AccountButton);
            _accountPage.ClickViewOrderHistoryButton();
            _accountPage.ClickViewOrderDetailsButton();
        }
    }
}
