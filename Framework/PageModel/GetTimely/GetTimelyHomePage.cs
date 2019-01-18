using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Drivers;
using Framework.Elements;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageModel.GetTimely
{
    public class GetTimelyHomePage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;

        [Name("Signup email field")]
        [FindsBy(How = How.XPath, Using = "//*[@id='homepage-top-email']")]
        private IWebElement _topEmailSignUp;

        [Name("Signup button")]
        [FindsBy(How = How.XPath, Using = "//*[@id='nav-get-started'][contains(text(),'Free')][contains(text(),'Trial')]")]
        private IWebElement _signUpButton;

        [Name("Login Link")]
        [FindsBy(How = How.XPath, Using = "//a[text()='Login']")]
        private IWebElement _loginLink;

        public GetTimelyHomePage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public void FillInEmailEntry()
        {
            _topEmailSignUp.Click();
            _topEmailSignUp.Clear();
            var email = $"{RandomStringHelper.GetRandomString(6)}.{RandomStringHelper.GetRandomString(8)}@random.com";
            _topEmailSignUp.SendKeys(email);
            Thread.Sleep(1000);
        }

        public void ClickToSignup()
        {
            _signUpButton.Click();
            Thread.Sleep(3000);
        }

        public void GoToLoginpage()
        {
            _loginLink.Click();
            Thread.Sleep(1500);
        }
    }
}
