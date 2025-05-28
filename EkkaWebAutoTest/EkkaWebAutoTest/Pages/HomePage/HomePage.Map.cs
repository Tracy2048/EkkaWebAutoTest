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
        public IWebElement UserButton => _driver.FindElements(By.CssSelector(".ec-header-user > button.dropdown-toggle")).FirstOrDefault(b => b.Displayed && b.Enabled);

        public IWebElement AccountButton => _driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/div/div[3]/div/div/ul/li[1]/a"));

        public IWebElement LogoutButton => _driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/div/div[3]/div/div/ul/li[3]/a"));

        public IWebElement CartIcon => _driver.FindElement(By.ClassName("fi-rr-shopping-bag"));

        public IWebElement ViewCartButton => _driver.FindElement(By.XPath("//*[@id=\"ec-side-cart\"]/div/div[2]/div[2]/a[1]"));

        public IWebElement ProductInStock => _driver.FindElement(By.XPath("//*[@title=\"Fairycore Ladies' Mushroom & Vine Embroidery Suspenders Mid-length Skirt\"]"));
        public IWebElement ProductOutStock => _driver.FindElement(By.XPath("//*[@title=\"1pc Plain Square Makeup Bag Black Friday\"]"));

        public IWebElement ProductRandom
        {
            get
            {
                var elements = _driver.FindElements(By.ClassName("main-image"));
                Random rnd = new Random();
                int[] allowedIndexes = { 1, 2, 3 };
                int randomIndex = allowedIndexes[rnd.Next(allowedIndexes.Length)];

                return elements[randomIndex];
            }
        }
    }
}
