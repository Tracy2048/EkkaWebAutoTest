using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.RegisterPage
{
    public partial class RegisterPage
    {
        private IWebDriver _driver;
        public string Url => "http://localhost/ecommerce/signup";
        public RegisterPage(IWebDriver driver) => _driver = driver;
        public void Open()
        {
            _driver.Navigate().GoToUrl(Url);
        }
        public void Register(string name, string email, string password)
        {
            NameTextBox.Clear();
            NameTextBox.SendKeys(name);
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            SignUpButton.Click();
        }
    }
}
