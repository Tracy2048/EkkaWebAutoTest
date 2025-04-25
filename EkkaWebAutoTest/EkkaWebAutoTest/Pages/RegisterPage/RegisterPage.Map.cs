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
        public IWebElement NameTextBox => _driver.FindElement(By.Name("fullname"));
        public IWebElement EmailTextBox => _driver.FindElement(By.Name("email"));

        public IWebElement PasswordTextBox => _driver.FindElement(By.Name("password"));

        public IWebElement SignUpButton => _driver.FindElement(By.XPath("//*[@id=\"btn_ele\"]"));

        public IWebElement EmailValidationMessage => _driver.FindElement(By.Id("swal2-title"));

        public IWebElement PasswordValidationMessage => _driver.FindElement(By.XPath("//span[@class='error'][2]"));
    }
}
