using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EkkaWebAutoTest.Tests
{
    public class LogoutTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

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
        public void Logout_Success()
        {
            _loginPage.Open();
            _loginPage.Login("hangt7708@gmail.com", "User1234@");
            //Console.WriteLine(_driver.PageSource);
            Thread.Sleep(WaitTimes.Default);
            _homePage = new HomePage(_driver);
            
            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _homePage.LogoutButton);
            Thread.Sleep(WaitTimes.Default);

            _homePage.UserButton.Click();
            Thread.Sleep(WaitTimes.Default);
            Assert.That(_driver.Url, Is.EqualTo("http://localhost/ecommerce/"));
        }
        
    }
}
