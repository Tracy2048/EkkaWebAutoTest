using EkkaWebAutoTest.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.CartPage
{
    public partial class CartPage
    {
        private IWebDriver _driver;
        public CartPage(IWebDriver driver) => _driver = driver;
        public void ClickIncreaseQuantityButton()
        {
            IncreaseQuantityButton.Click();
            Thread.Sleep(WaitTimes.Short);
        }
        public void ClickDecreaseQuantityButton()
        {
            DecreaseQuantityButton.Click();
            Thread.Sleep(WaitTimes.Short);
        }
        public void EnterQuantity(string quantity)
        {
            QuantityTextBox.Clear();
            QuantityTextBox.SendKeys(quantity);
            Thread.Sleep(WaitTimes.Short);
        }

        public void ClickCheckoutButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", CheckoutButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", CheckoutButton);
            Thread.Sleep(WaitTimes.Short);
        }
    }
}
