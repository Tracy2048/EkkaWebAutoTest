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
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

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
        public void Login_Success()
        {
            _loginPage.Open();
            _loginPage.Login("hangt7708@gmail.com", "User1234@");
            _loginPage.AssertLoginSuccess();
        }

        [Test]
        public void Login_EmptyEmail()
        {
            _loginPage.Open();
            _loginPage.Login(string.Empty, "User1234@");
            _loginPage.AssertEmptyEmail();
        }

        [Test]
        public void Login_EmptyPassword()
        {
            _loginPage.Open();
            _loginPage.Login("hangt7708@gmail.com", string.Empty);
            _loginPage.AssertEmptyPassword();
        }

        [Test]
        public void Login_IncorrectEmail()
        {
            _loginPage.Open();
            _loginPage.Login("user@gmail.com", "User1234@");
            _loginPage.AssertIncorrectEmailOrPassword();
        }

        [Test]
        public void Login_IncorrectPassword()
        {
            _loginPage.Open();
            _loginPage.Login("hangt@gmail.com", "User123");
            _loginPage.AssertIncorrectEmailOrPassword();
        }
    }
}
