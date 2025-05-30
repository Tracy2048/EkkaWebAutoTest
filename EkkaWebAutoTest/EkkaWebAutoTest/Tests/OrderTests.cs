using EkkaWebAutoTest.Constants;
using EkkaWebAutoTest.Pages.CartPage;
using EkkaWebAutoTest.Pages.HomePage;
using EkkaWebAutoTest.Pages.LoginPage;
using EkkaWebAutoTest.Pages.OrderPage;
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
    public class OrderTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private ProductPage _productPage;
        private CartPage _cartPage;
        private OrderPage _orderPage;

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
            _orderPage = new OrderPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Order_CartEmpty()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account2.email, AccountStore.Account2.password);
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.AssertCartEmpty();
        }

        [Test]
        public void Order_COD()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(AccountStore.Account1.name, AccountStore.Account1.phone, 
                             AccountStore.Account1.address, _orderPage.COD_Radio);
            _orderPage.AssertOrderSuccess();
        }

        [Test]
        public void Order_VNPAY()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(AccountStore.Account1.name, AccountStore.Account1.phone,
                             AccountStore.Account1.address, _orderPage.VNPAY_Radio);
            //_orderPage.AssertOrderSuccess();
        }

        [Test]
        public void Order_MOMO()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(AccountStore.Account1.name, AccountStore.Account1.phone,
                             AccountStore.Account1.address, _orderPage.MOMO_Radio);
            //_orderPage.AssertOrderSuccess();
        }

        [Test]
        public void CheckQuantity_AfterOrder()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(AccountStore.Account1.name, AccountStore.Account1.phone,
                             AccountStore.Account1.address, _orderPage.COD_Radio);
            _homePage.Open();
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            var quantity = _productPage.ProductStock.Text;
            _orderPage.AssertCheckQuantity_AfterOrder(quantity);
        }

        [Test]
        public void Order_EmptyInfo()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(string.Empty, string.Empty, string.Empty, _orderPage.COD_Radio);
            _orderPage.AssertEmptyInfo();
        }

        [Test]
        public void Order_InvalidPhone()
        {
            _loginPage.Open();
            _loginPage.Login(AccountStore.Account1.email, AccountStore.Account1.password);
            _homePage.ClickOnProduct(_homePage.ProductInStock);
            _productPage.ClickTypeProduct(_productPage.TypeInStockButton);
            _productPage.ClickAddToCartButton();
            _homePage.ClickOnCart();
            _cartPage.ClickCheckoutButton();
            _orderPage.Order(AccountStore.Account1.name,"0123" , AccountStore.Account1.address, _orderPage.COD_Radio);
            _orderPage.AssertInvalidPhone();
        }
    }
}
