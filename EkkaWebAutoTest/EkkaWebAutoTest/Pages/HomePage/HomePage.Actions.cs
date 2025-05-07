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

        
    }
}
