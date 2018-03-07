using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Drivers;
using Framework.Elements;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageModel.GetTimely
{
    public class FreeTrialSetUpPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("Free Trial Banner")]
        [FindsBy(How = How.XPath, Using = "//h1")]
        private IWebElement _freeTrialBanner;

        public FreeTrialSetUpPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public string GetTrialBannerText()
        {
            if (ElementHelper.ValidateElement(_freeTrialBanner, _freeTrialBanner.GetAttribute("Name")))
            {
                return _freeTrialBanner.Text;
            }
            throw new Exception("Trial Banner is not displayed");
        }
    }
}
