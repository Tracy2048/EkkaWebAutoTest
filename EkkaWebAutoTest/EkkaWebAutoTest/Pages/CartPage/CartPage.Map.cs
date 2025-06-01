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
        public IWebElement IncreaseQuantityButton => _driver.FindElement(By.XPath("//*[@id=\"cart_main\"]/tr/td[3]/div/div/div[1]"));
        public IWebElement DecreaseQuantityButton => _driver.FindElement(By.XPath("//*[@id=\"cart_main\"]/tr/td[3]/div/div/div[2]"));
        public IWebElement QuantityTextBox => _driver.FindElement(By.Name("cartqtybutton"));
        public IWebElement DeleteIcon => _driver.FindElement(By.XPath("//*[@id=\"cart_main\"]/tr/td[5]/button"));
        public IWebElement CheckoutButton => _driver.FindElement(By.XPath("/html/body/div[2]/main/section/div/div/div[1]/div/div/div/form/div[2]/div/div/a[2]"));
        
        public int total = 1;

        public string message = "";

        
    }
}
