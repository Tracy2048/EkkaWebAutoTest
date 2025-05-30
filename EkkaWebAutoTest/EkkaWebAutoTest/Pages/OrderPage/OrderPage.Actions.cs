using EkkaWebAutoTest.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.OrderPage
{
    public partial class OrderPage
    {
        private IWebDriver _driver;
        public OrderPage(IWebDriver driver) => _driver = driver;
        public void Order(string name, string phone, string address, IWebElement element)
        {
            NameTextBox.Clear();
            NameTextBox.SendKeys(name);
            PhoneTextBox.Clear();
            PhoneTextBox.SendKeys(phone);
            AddressTextBox.Clear();
            AddressTextBox.SendKeys(address);
            Thread.Sleep(WaitTimes.Short);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(WaitTimes.Short);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", OrderButton);
            Thread.Sleep(WaitTimes.Short);
        }

        
    }
}
