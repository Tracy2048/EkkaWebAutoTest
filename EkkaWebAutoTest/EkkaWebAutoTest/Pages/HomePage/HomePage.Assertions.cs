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
    }
}
