using EkkaWebAutoTest.Pages.LoginPage;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkkaWebAutoTest.Pages.AccountPage;
using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.HomePage;
using System.Xml.Linq;

namespace EkkaWebAutoTest.Tests
{
    public class AccountTests
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
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void ViewAccount()
        {
            _loginPage.Open();
            _loginPage.Login("hangt7708@gmail.com", "User1234@");
            Thread.Sleep(WaitTimes.Default);

            _homePage = new HomePage(_driver);
            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _homePage.AccountButton);

            _accountPage = new AccountPage(_driver);
            ((IJavaScriptExecutor)_driver).ExecuteScript(@"
                var rect = arguments[0].getBoundingClientRect();
                window.scrollTo({ top: window.pageYOffset + rect.top - (window.innerHeight / 2) });
                ", _accountPage.Name);

            Thread.Sleep(WaitTimes.Default);
            _accountPage.AssertViewAccount();
        }
    }
}
