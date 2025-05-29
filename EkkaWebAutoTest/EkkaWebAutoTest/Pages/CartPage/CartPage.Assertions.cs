using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.CartPage
{
    public partial class CartPage
    {
        public void AssertCheckTotal()
        {
            Assert.That(total, Is.EqualTo(50), "Không cập nhật");
        }
        public void AssertCheckMessage_InvalidNumber()
        {
            Assert.That(message, Is.EqualTo("Vui lòng kiểm tra lại số lượng."), "Không thông báo");
        }
        public void AssertCheckMessage_Invalid()
        {
            Assert.That(message, Is.EqualTo("Vui lòng nhập số hợp lệ."), "Không thông báo");
        }
    }
}
