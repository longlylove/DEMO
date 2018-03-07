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
    public class CalendarPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("Timely Nav")]
        [FindsBy(How = How.XPath, Using = "//div[@class='timelyNav']")]
        private IWebElement _timelyNav;

        public CalendarPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public bool IsCalendarNavigationDisplayed()
        {
            if (ElementHelper.ValidateElement(_timelyNav, _timelyNav.GetAttribute("Name")))
            {
                return true;
            }
            return false;
        }
    }
}
