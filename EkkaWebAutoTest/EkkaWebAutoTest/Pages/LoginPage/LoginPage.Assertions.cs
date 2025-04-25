using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.LoginPage
{
    public partial class LoginPage
    {
        public void AssertLoginValidation()
        {
            var alertText = _driver.FindElement(By.XPath("//div[@class='swal2-html-container']")).Text;
            Assert.AreEqual("Đăng nhập thành công.", alertText);
        }
    }
}
