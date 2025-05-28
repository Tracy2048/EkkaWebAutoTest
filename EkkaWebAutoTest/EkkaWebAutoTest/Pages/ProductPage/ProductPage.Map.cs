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
        public IWebElement NameProduct => _driver.FindElement(By.XPath("/html/body/div[2]/main/section[1]/div/div/div/div[1]/div/div/div[2]/div/h5"));
        public IWebElement TypeInStockButton => _driver.FindElement(By.Id("132"));
        public IWebElement TypeOutStockButton => _driver.FindElement(By.Id("114"));
        public IWebElement AddToCartButton => _driver.FindElement(By.Id("add-Product-To-Cart"));

    }
}
