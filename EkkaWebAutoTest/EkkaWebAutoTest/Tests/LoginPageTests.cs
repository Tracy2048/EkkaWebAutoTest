using EkkaWebAutoTest.Pages.LoginPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Tests
{
    public class LoginPageTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            _loginPage = new LoginPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        [Test]
        public void LoginAttempt()
        {
            _loginPage.Open();

            _loginPage.Login("hangt7708@gmail.com", "User1234@");

            var popup = _driver.FindElement(By.CssSelector(".swal2-popup"));
            Assert.IsTrue(popup.Displayed);


        }


    }
}
