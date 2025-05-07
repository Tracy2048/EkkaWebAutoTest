using EkkaWebAutoTest.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.LoginPage
{
    public partial class LoginPage
    {
        private IWebDriver _driver;
        public string Url => "http://localhost/ecommerce/login";
        public LoginPage(IWebDriver driver) => _driver = driver;
        public void Open()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void Login(string email, string password)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            Thread.Sleep(WaitTimes.Default);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", LoginButton);
            // Đợi cho loginButton visible & enabled
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => LoginButton.Displayed && LoginButton.Enabled);

            // Click bằng JavaScript
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", LoginButton);
        }
    }
}
