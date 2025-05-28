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
    }
}
