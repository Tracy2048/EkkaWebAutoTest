using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.ProductPage
{
    public partial class ProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IWebDriver driver) => _driver = driver;
        public void ClickTypeProduct(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
        public void ClickAddToCartButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", AddToCartButton);
        }
    }
}
