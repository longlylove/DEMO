using System.Collections.Generic;
using Framework.Drivers;
using Framework.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageModel.BookDepo
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;

        [Name("Search Result Head Line")] 
        [FindsBy(How = How.XPath, Using = "//div[@class='main-content search-page']/h1")]
        private IWebElement _searchResultHeadLine;

        [Name("Book Titles")]
        [FindsBy(How = How.XPath, Using = "//div[@class='book-item']/div[@class='item-info']/h3[@class='title']/a")]
        private IList<IWebElement> _bookTitles;

        [Name("Book Titles")]
        private IWebElement _singleTitle;
        public SearchResultPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public bool BooksAreFound(string bookTitle)
        {
            var found = false;
            var totalFound = CountTotalFoundBook();
            if (totalFound <= 0) return false;
            for (var i = 1; i <= totalFound; i++)
            {
                _singleTitle =
                    _driverInUse.FindElement(
                        By.XPath("//div[@class='book-item'][" + i + "]/div[@class='item-info']/h3[@class='title']/a"));
                var titleText = _singleTitle.Text;
                if (titleText.ToLower().Contains(bookTitle.ToLower()))
                {
                    found = true;
                }
            }
            return found;
        }

        private int CountTotalFoundBook()
        {
            return _bookTitles.Count;
        }
    }
}
