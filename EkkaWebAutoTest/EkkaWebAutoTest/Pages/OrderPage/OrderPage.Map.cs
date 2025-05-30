using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.OrderPage
{
    public partial class OrderPage
    {
        public IWebElement NameTextBox => _driver.FindElement(By.Name("fullname"));
        public IWebElement PhoneTextBox => _driver.FindElement(By.Name("phone"));
        public IWebElement AddressTextBox => _driver.FindElement(By.Name("address"));
        public IWebElement Message => _driver.FindElement(By.XPath("//*[@id=\"swal2-title\"]"));
        public IWebElement OrderButton => _driver.FindElement(By.XPath("/html/body/div[2]/main/div/form/section/div/div/div[1]/div/div/span/button"));
        public IWebElement COD_Radio => _driver.FindElement(By.XPath("/html/body/div[2]/main/div/form/section/div/div/div[2]/div[2]/div/div[2]/div/div[2]/span[1]/span/label"));
        public IWebElement VNPAY_Radio => _driver.FindElement(By.XPath("/html/body/div[2]/main/div/form/section/div/div/div[2]/div[2]/div/div[2]/div/div[2]/span[2]/span/label"));
        public IWebElement MOMO_Radio => _driver.FindElement(By.XPath("/html/body/div[2]/main/div/form/section/div/div/div[2]/div[2]/div/div[2]/div/div[2]/span[3]/span/label"));

        public int quantityBefore = 222;
    }
}
