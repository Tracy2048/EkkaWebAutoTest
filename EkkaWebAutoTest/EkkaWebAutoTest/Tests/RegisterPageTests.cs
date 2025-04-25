
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkkaWebAutoTest.Pages.RegisterPage;

namespace EkkaWebAutoTest.Tests
{
    public class RegisterPageTests
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            _registerPage = new RegisterPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        [Test]
        public void Register()
        {
            _registerPage.Open();

            _registerPage.Register("User","user@gmail.com", "User1234@");

            Assert.That(_driver.Url, Is.EqualTo("http://localhost/ecommerce/login"));
        }
    }
}
