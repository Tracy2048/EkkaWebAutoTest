using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.AccountPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EkkaWebAutoTest.Pages.HomePage
{
    public partial class HomePage
    {
        private IWebDriver _driver;
        public string Url => "http://localhost/ecommerce/home";
        public HomePage(IWebDriver driver) => _driver = driver;
        public void Open()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void ClickOnProduct(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                "arguments[0].scrollIntoView({block: 'center'});", element);

            Thread.Sleep(WaitTimes.Default);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(WaitTimes.Default);
        }

        public void ClickOnCart()
        {
            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", CartIcon);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ViewCartButton);

            //ViewCartButton.Click();
            Thread.Sleep(WaitTimes.Default);

        }

        public void SearchProduct(string productName)
        {
            SearchTextBox.Clear();
            SearchTextBox.SendKeys(productName);
            Thread.Sleep(WaitTimes.Default);
            SearchTextBox.SendKeys(Keys.Enter);
            Thread.Sleep(WaitTimes.Default);
        }

        public void ClickDeleteButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", DeleteButton);
        }

        
    }
}
