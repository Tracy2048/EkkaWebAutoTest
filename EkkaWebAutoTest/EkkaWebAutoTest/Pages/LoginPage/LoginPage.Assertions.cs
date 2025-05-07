using EkkaWebAutoTest.Constants;
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
            Thread.Sleep(WaitTimes.Default);
        }

        public void AssertEmptyEmail()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng không để trống email."));
            Thread.Sleep(WaitTimes.Default);
        }

        public void AssertEmptyPassword()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng không để trống mật khẩu."));
            Thread.Sleep(WaitTimes.Default);
        }

        public void AssertIncorrectEmailOrPassword()
        {
            Assert.That(Message.Text, Is.EqualTo("Email hoặc mật khẩu không chính xác."));
            Thread.Sleep(WaitTimes.Default);
        }
    }
}
