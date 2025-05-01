using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkkaWebAutoTest.Pages.SignUpPage;

namespace EkkaWebAutoTest.Tests
{
    public class SignUpPageTests
    {
        private IWebDriver _driver;
        private SignUpPage _signUpPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _signUpPage = new SignUpPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        [Test]
        public void SignUp_Sucess()
        {
            _signUpPage.Open();
            _signUpPage.SignUp("Hang", "user@gmail.com", "User1234@");
        }
        [Test]
        public void SignUp_ExistingEmail()
        {
            _signUpPage.Open();
            _signUpPage.SignUp("Hang", "user@gmail.com", "User1234@");
            _signUpPage.AssertExistingEmail();
        }
    }
}
