using EkkaWebAutoTest.Constants;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.ProductPage
{
    public partial class ProductPage
    {
        public void AssertProductName(string name)
        {
            Assert.That(NameProduct.Text.ToLower(), Is.EqualTo(name.ToLower()));
        }
        public void AssertAddProductSuccess()
        {
            Assert.That(Message.Text, Is.EqualTo("Thêm sản phẩm vào giỏ hàng thành công."));
            Thread.Sleep(WaitTimes.Short);
        }
        public void AssertAddProductOutStock()
        {
            Assert.That(AddToCartButton.Text, Is.EqualTo("SẢN PHẨM TẠM HẾT"));
            Thread.Sleep(WaitTimes.Short);
        }
        public void AssertCheckQuantity()
        {
            Assert.That(Message.Text, Is.EqualTo("Vui lòng kiểm tra lại số lượng."));
            Thread.Sleep(WaitTimes.Default);
        }
    }
}
