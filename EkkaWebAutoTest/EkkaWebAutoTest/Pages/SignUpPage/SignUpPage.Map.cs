using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.SignUpPage
{
    public partial class SignUpPage
    {
        public IWebElement NameTextBox => _driver.FindElement(By.Name("fullname"));

        public IWebElement EmailTextBox => _driver.FindElement(By.Name("email"));

        public IWebElement PasswordTextBox => _driver.FindElement(By.Name("password"));

        public IWebElement SignUpButton => _driver.FindElement(By.XPath("//*[@id=\"btn_ele\"]"));

        public IWebElement Message => _driver.FindElement(By.XPath("//*[@id=\"swal2-title\"]"));

    }
}
