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
    }
}
