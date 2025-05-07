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
        //var elements = _driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/div[3]/div/div/ul/li[3]/a"));
        //Console.WriteLine("Số lượng phần tử tìm thấy: " + elements.Count);
        public void ScrollAndClickElement(IWebElement element, IWebDriver _driver)
        {
            // Cuộn đến phần tử
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Đợi cho phần tử hiển thị và có thể nhấp được
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => element.Displayed && element.Enabled);

            // Nhấp vào phần tử bằng JavaScript
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}
