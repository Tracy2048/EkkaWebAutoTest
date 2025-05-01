using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement EmailTextBox => _driver.FindElement(By.Name("email"));

        public IWebElement PasswordTextBox => _driver.FindElement(By.Name("password"));

        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("button.btn.btn-primary.rounded-1"));

        public IWebElement Message => _driver.FindElement(By.XPath("//*[@id=\"swal2-title\"]"));

    }
}
