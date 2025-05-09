using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.AccountPage;
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
    }
}
