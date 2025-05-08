using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.AccountPage
{
    public partial class AccountPage
    {
        public IWebElement Name => _driver.FindElement(By.ClassName("name"));
        public IWebElement Email => _driver.FindElement(By.XPath("/html/body/div[2]/main/section/div/div/div[2]/div/div/div/div/div/div[2]/div[1]/div/ul/li[1]"));
    }
}
