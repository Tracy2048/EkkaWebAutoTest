using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement UserButton => _driver.FindElements(By.CssSelector(".ec-header-user > button.dropdown-toggle")).FirstOrDefault(b => b.Displayed && b.Enabled);

        public IWebElement AccountButton => _driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/div/div[3]/div/div/ul/li[1]/a"));

        public IWebElement LogoutButton => _driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/div/div[3]/div/div/ul/li[3]/a"));
    }
}
