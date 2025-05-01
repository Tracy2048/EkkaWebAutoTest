using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.SignUpPage
{
    public partial class SignUpPage
    {
        private IWebDriver _driver;
        public string Url => "http://localhost/ecommerce/signup";
        public SignUpPage(IWebDriver driver) => _driver = driver;
        public void Open()
        {
            _driver.Navigate().GoToUrl(Url);
        }
        public void SignUp(string name, string email, string password)
        {
            NameTextBox.Clear();
            NameTextBox.SendKeys(name);
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            Thread.Sleep(1500);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", SignUpButton);
            // Đợi cho loginButton visible & enabled
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => SignUpButton.Displayed && SignUpButton.Enabled);

            // Click bằng JavaScript
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignUpButton);
        }
    }
}
