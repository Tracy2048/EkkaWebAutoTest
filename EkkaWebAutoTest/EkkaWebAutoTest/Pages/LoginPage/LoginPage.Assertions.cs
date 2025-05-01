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
        public void AssertLoginSuccess()
        {
            Assert.That(Message.Text, Is.EqualTo("Đăng nhập thành công."));
            Thread.Sleep(1500);
        }
    }
}
