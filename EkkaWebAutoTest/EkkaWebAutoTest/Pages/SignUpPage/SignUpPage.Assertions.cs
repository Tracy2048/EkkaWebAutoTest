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
        public void AssertExistingEmail()
        {
            Assert.That(EmailValidationMessage.Text, Is.EqualTo("Email đã tồn tại vui lòng đăng nhập."));
            Thread.Sleep(1500);
        }
    }
}
