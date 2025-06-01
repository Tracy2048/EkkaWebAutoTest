using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.CartPage;
using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using EkkaWebAutoTest.Pages.ProductPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Tests
{
    public class CartTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private ProductPage _productPage;
        private CartPage _cartPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _productPage = new ProductPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Cart_Without_Login()
        {
            _homePage.Open();
            _homePage.ClickOnCart();
            _homePage.AssertOnLoginPage();
        }

        [Test]
        public void Cart_Empty()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account2.email, AccountStore.Account2.password);
            _homePage.ClickOnCart();
            _cartPage.AssertCartEmpty();
        }

        [Test]
        public void AddProduct_Without_Login()
        {
            _homePage.Open();
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.AssertOnLoginPage();
        }

        [Test]
        public void AddProduct_After_Login()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _productPage.AssertAddProductSuccess();
        }

        [Test]
        public void AddProduct_Duplicate()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            Thread.Sleep(WaitTimes.Short);
            _productPage.ClickAddToCartButton();
            _productPage.AssertAddProductSuccess();
        }

        [Test]
        public void AddProduct_OutStock()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductOutStock);
            _productPage.ClickTypeProduct(_productPage.TypeOutStockButton);
            _productPage.AssertAddProductOutStock();
        }

        [Test]
        public void AddProduct_OverStock()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.EnterQuantity("10000");
            _productPage.ClickAddToCartButton();
            _productPage.AssertCheckQuantity();
        }

        [Test]
        public void AddProduct_NegativeQuantity()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.EnterQuantity("-1");
            _productPage.ClickAddToCartButton();
            _productPage.AssertCheckQuantity();
        }

        [Test]
        public void Cart_IncreaseQuantity_ByButton()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            int quantityBefore = int.Parse(_cartPage.QuantityTextBox.GetAttribute("value"));
            _cartPage.ClickIncreaseQuantityButton();
            int quantityAfter = int.Parse(_cartPage.QuantityTextBox.GetAttribute("value"));
            Assert.That(quantityAfter, Is.EqualTo(quantityBefore + 1), "Giá trị không tăng");
        }

        [Test]
        public void Cart_DecreaseQuantity_ByButton()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            int quantityBefore = int.Parse(_cartPage.QuantityTextBox.GetAttribute("value"));
            _cartPage.ClickDecreaseQuantityButton();
            int quantityAfter = int.Parse(_cartPage.QuantityTextBox.GetAttribute("value"));
            Assert.That(quantityAfter, Is.EqualTo(quantityBefore - 1), "Giá trị không giảm");
        }

        [Test]
        public void Cart_IncreaseQuantity_OverStock()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickDeleteButton();
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.EnterQuantity(_productPage.ProductStock.Text);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickIncreaseQuantityButton();
            _productPage.AssertCheckQuantity();
        }

        [Test]
        public void Cart_DecreaseQuantity_ToZero()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickDeleteButton();
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickDecreaseQuantityButton();
            _productPage.AssertCheckQuantity();
        }

        [Test]
        public void Cart_EnterQuantity_ToTextBox()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            _cartPage.EnterQuantity("50");
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].blur();", _cartPage.QuantityTextBox);
            _cartPage.AssertCheckTotal();
        }

        [Test]
        public void Cart_EnterQuantity_InvalidNumber()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            _cartPage.EnterQuantity("-1");
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].blur();", _cartPage.QuantityTextBox);
            _cartPage.AssertCheckMessage_InvalidNumber();
        }

        [Test]
        public void Cart_EnterQuantity_Invalid()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            _cartPage.EnterQuantity("number");
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].blur();", _cartPage.QuantityTextBox);
            _cartPage.AssertCheckMessage_Invalid();
        }

        [Test]
        public void Cart_ViewSomeProduct()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            //_homePage.ClickOnProduct(_homePage.ProductInStock);
            //_productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            //_productPage.ClickAddToCartButton();
            //_homePage.Open();
            _homePage.ClickOnProduct(_homePage.ProductInStock2);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton2);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
        }

        [Test]
        public void Cart_DeleteProduct()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnCart();
            _cartPage.DeleteIcon.Click();
            Thread.Sleep(WaitTimes.Short);
            _cartPage.DeleteIcon.Click();
        }
    }
}
