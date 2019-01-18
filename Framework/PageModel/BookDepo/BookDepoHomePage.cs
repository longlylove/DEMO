using System;
using System.Threading;
using Framework.Drivers;
using Framework.Elements;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageModel.BookDepo
{
    public class BookDepoHomePage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("Search Bar")] 
        [FindsBy(How = How.XPath, Using = "//form[@id='book-search-form']//input[@name='searchTerm']")] 
        private IWebElement _searchInput;

        [Name("Search Button")]
        [FindsBy(How = How.XPath, Using = "//form[@id='book-search-form']//button[@aria-label='Search']")]
        private IWebElement _searchButton;

        public BookDepoHomePage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public void SearchForBook(string title = null, string isbn = null)
        {
            _searchInput.Clear();
            if (title != null)
            {
                _searchInput.SendKeys(title);
            }
            if (isbn != null)
            {
                _searchInput.SendKeys(isbn);
            }
            _searchButton.Click();
            Thread.Sleep(5000);
        }

        public bool SearchBarIsAvaialble()
        {
            if (ElementHelper.ValidateElement(_searchButton, _searchButton.GetAttribute("Name"))
                && ElementHelper.ValidateElement(_searchInput, _searchInput.GetAttribute("Name")))
            {
                return true;
            }
            throw new Exception("Search bar is not availalble");
        }
    }
}
