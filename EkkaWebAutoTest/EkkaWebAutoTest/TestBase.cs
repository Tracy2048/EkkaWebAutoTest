using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest
{
    public class TestBase
    {
        //public IWebDriver driver { get; set; }

        //[SetUp]
        //public void BaseSetUp()
        //{
        //    driver = DriverProvider.GetChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        //}

        //[TearDown]
        //public void CleanUp()
        //{
        //    driver.Close();
        //    driver.Dispose();
        //}
        //public static void SafeClick(IWebDriver driver, IWebElement element, int timeoutInSeconds = 5)
        //{
        //    try
        //    {
        //        // Scroll đến element
        //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

        //        // Đợi cho element thực sự clickable
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

        //        // Click
        //        element.Click();
        //    }
        //    catch (WebDriverException ex)
        //    {
        //        throw new Exception($"SafeClick failed on element {element}. Error: {ex.Message}", ex);
        //    }
        //}
    }
}
