using EkkaWebAutoTest.Constants;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.SignUpPage
{
    public partial class SignUpPage
    {
        public void AssertSignUpSucess()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng xác nhận email để hoàn tất đăng ký."));
            Thread.Sleep(WaitTimes.Default);
        }
        public void AssertExistingEmail()
        {
            Assert.That(Message.Text, Is.EqualTo("Email đã tồn tại vui lòng đăng nhập."));
            Thread.Sleep(WaitTimes.Default);
        }
        public void AssertEmptyName()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng không để trống họ và tên."));
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
    }
}
