using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkkaWebAutoTest.Pages.CheckoutPage
{
    public partial class CheckoutPage
    {
        // Elements for Checkout With NCB Bank Payment
        public IWebElement BankListButton => _driver.FindElement(By.XPath("//*[@id=\"accordionList\"]/div[2]/div[1]/div/div[1]/div"));
        public IWebElement NCBBankButton => _driver.FindElement(By.Id("NCB"));
        public IWebElement CardNumberTextBox => _driver.FindElement(By.Id("card_number_mask"));
        public IWebElement CardHolderTextBox => _driver.FindElement(By.Id("cardHolder"));
        public IWebElement IssueDateTextBox => _driver.FindElement(By.Id("cardDate"));
        public IWebElement ContinueButton => _driver.FindElement(By.Id("btnContinue"));
        public IWebElement AgreeButton => _driver.FindElement(By.Id("btnAgree"));
        public IWebElement OTPTextBox => _driver.FindElement(By.Id("otpvalue"));
        public IWebElement ConfirmButton => _driver.FindElement(By.Id("btnConfirm"));

        // Elements for Checkout With MOMO
        public IWebElement MOMO_CardNumberTextBox => _driver.FindElement(By.Id("card-number"));
        public IWebElement MOMO_CardHolderTextBox => _driver.FindElement(By.Id("card-name"));
        public IWebElement MOMO_IssueDateTextBox => _driver.FindElement(By.Id("card-expire"));
        public IWebElement MOMO_PhoneTextBox => _driver.FindElement(By.Id("number-phone"));
        public IWebElement MOMO_ContinueButton => _driver.FindElement(By.Id("btn-pay-card"));
        public IWebElement MOMO_OTPTextBox => _driver.FindElement(By.Id("napasOtpCode"));
        public IWebElement MOMO_ConfirmButton => _driver.FindElement(By.Id("napasProcessBtn1"));
    }
}
