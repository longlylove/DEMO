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
    public class LoginPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("Username Field")]
        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement _userNameInput;

        [Name("Pwd Field")]
        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement _pwdInput;

        [Name("Login button")]
        [FindsBy(How = How.XPath, Using = "//button[text()='Log in']")]
        private IWebElement _loginButton;

        public LoginPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public void IsLoginPageDisplayed()
        {
            Thread.Sleep(2500);
            var title = JsExecutor.Execute("return document.title");
            if (title == "Login to Timely")
            {
                if (ElementHelper.ValidateElement(_userNameInput, _userNameInput.GetAttribute("Name"))
                && ElementHelper.ValidateElement(_pwdInput, _pwdInput.GetAttribute("Name"))
                && ElementHelper.ValidateElement(_loginButton, _loginButton.GetAttribute("Name")))
                return;
            }
            throw new Exception("Login page was not displayed");
        }

        public void FillInCredentials()
        {
            _userNameInput.Click();
            _userNameInput.SendKeys("random@test.xero.com");
            _pwdInput.Click();
            _pwdInput.SendKeys("abcd1234");
            Thread.Sleep(1000);
        }

        public void ClickToLogin()
        {
            _loginButton.Click();
            WaitFor.Implicitly();
        }
    }
}