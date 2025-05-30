using EkkaWebAutoTest.Constants;
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
        private IWebDriver _driver;
        //public string Url => "http://localhost/ecommerce/my-account";
        public AccountPage(IWebDriver driver) => _driver = driver;
        //public void Open()
        //{
        //    _driver.Navigate().GoToUrl(Url);
        //}
        public void ClickViewOrderHistoryButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ViewOrderHistoryButton);
            Thread.Sleep(WaitTimes.Default);
        }
        public void ClickViewOrderDetailsButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ViewOrderDetailsButton);
            Thread.Sleep(WaitTimes.Short);
        }
    }
}
