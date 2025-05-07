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
    public class SignUpTests
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
            _signUpPage.AssertSignUpSucess();
        }

        [Test]
        public void SignUp_ExistingEmail()
        {
            _signUpPage.Open();
            _signUpPage.SignUp("Hang", "hangt7708@gmail.com", "User1234@");
            _signUpPage.AssertExistingEmail();
        }

        [Test]
        public void SignUp_EmptyName()
        {
            _signUpPage.Open();
            _signUpPage.SignUp(string.Empty, "user@gmail.com", "User1234@");
            _signUpPage.AssertEmptyName();
        }

        [Test]
        public void SignUp_EmptyEmail()
        {
            _signUpPage.Open();
            _signUpPage.SignUp("User", string.Empty, "User1234@");
            _signUpPage.AssertEmptyEmail();
        }

        [Test]
        public void SignUp_EmptyPassword()
        {
            _signUpPage.Open();
            _signUpPage.SignUp("User", "user@gmail.com", string.Empty);
            _signUpPage.AssertEmptyPassword();
        }
    }
}
