using EkkaWebAutoTest.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.AccountPage
{
    public partial class AccountPage
    {
        public void AssertViewAccount()
        {
            Assert.That(Name.Text, Is.EqualTo("TRẦN HẰNG"));
            Assert.That(Email.Text, Does.Contain("hangt7708@gmail.com"));
        }
        public void AssertOrderHistoryEmpty()
        {
            Assert.That(message, Is.EqualTo("Bạn chưa có đơn hàng nào."), "Không thông báo");
        }
    }
}
