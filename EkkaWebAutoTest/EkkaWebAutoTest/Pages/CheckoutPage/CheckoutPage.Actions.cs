using EkkaWebAutoTest.Constants;
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
        private IWebDriver _driver;
        public CheckoutPage(IWebDriver driver) => _driver = driver;

        public void CheckoutWithNCB()
        {
            BankListButton.Click();
            NCBBankButton.Click();
            CardNumberTextBox.Clear();
            CardNumberTextBox.SendKeys(AccountNCB.CardNumber);
            CardHolderTextBox.Clear();
            CardHolderTextBox.SendKeys(AccountNCB.CardHolder);
            IssueDateTextBox.Clear();
            IssueDateTextBox.SendKeys(AccountNCB.IssueDate);
            Thread.Sleep(WaitTimes.Short);
            ContinueButton.Click();
            Thread.Sleep(WaitTimes.Short);
            AgreeButton.Click();
            OTPTextBox.Clear();
            OTPTextBox.SendKeys(AccountNCB.OTP);
            Thread.Sleep(WaitTimes.Short);
            ConfirmButton.Click();
            Thread.Sleep(WaitTimes.Short);
        }

        public void CheckoutWithMOMO()
        {
            MOMO_CardNumberTextBox.Clear();
            MOMO_CardNumberTextBox.SendKeys(AccountMOMO.CardNumber);
            MOMO_CardHolderTextBox.Clear();
            MOMO_CardHolderTextBox.SendKeys(AccountMOMO.CardHolder);
            MOMO_IssueDateTextBox.Clear();
            MOMO_IssueDateTextBox.SendKeys(AccountMOMO.IssueDate);
            MOMO_PhoneTextBox.Clear();
            MOMO_PhoneTextBox.SendKeys(AccountStore.Account1.phone);
            Thread.Sleep(WaitTimes.Short);
            MOMO_ContinueButton.Click();
            MOMO_OTPTextBox.Clear();
            MOMO_OTPTextBox.SendKeys(AccountMOMO.OTP);
            Thread.Sleep(WaitTimes.Short);
            MOMO_ConfirmButton.Click();
            Thread.Sleep(WaitTimes.Default);
        }
    }
}
