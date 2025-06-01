using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.HomePage
{
    public partial class HomePage
    {
        public void AssertOnLoginPage()
        {
            Assert.That(_driver.Url, Is.EqualTo("http://localhost/ecommerce/login"));
        }
        public void AssertSearchNotFound()
        {
            Assert.That(message, Is.EqualTo("Không có sản phẩm phù hợp."), "Không thông báo");
        }
    }
}
