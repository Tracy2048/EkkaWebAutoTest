using EkkaWebAutoTest.Constants;
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
        public void AssertCartEmpty()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng thêm sản phẩm vào giỏ hàng."),"Không thông báo");
            Thread.Sleep(WaitTimes.Short);
        }
        public void AssertOrderSuccess()
        {
            Assert.That(Message.Text, Is.EqualTo("Bạn đã đặt hàng thành công."), "Không thông báo");
            Thread.Sleep(WaitTimes.Short);
        }

        public void AssertCheckQuantity_AfterOrder(string quantity)
        {
            Assert.That(int.Parse(quantity), Is.EqualTo(quantityBefore-1), "Số lượng không đúng");
        }

        public void AssertEmptyInfo()
        {
            bool isValid = (bool)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].checkValidity();", NameTextBox);
            Assert.IsFalse(isValid, "Not required input");
        }

        public void AssertInvalidPhone()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng nhập đúng số điện thoại."), "Không thông báo");
            Thread.Sleep(WaitTimes.Short);
        }
    }
}
