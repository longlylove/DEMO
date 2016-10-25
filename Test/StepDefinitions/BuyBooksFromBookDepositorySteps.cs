using Framework.DataModel.BookDepo;
using Framework.PageModel.BookDepo;
using TechTalk.SpecFlow;
using Test.Infrastructure;
using Xunit;

namespace Test.StepDefinitions
{
    [Binding, Scope(Feature = "BuyBooksFromBookDepository")]
    public class BuyBooksFromBookDepositorySteps : Steps
    {
        private readonly BookDepoHomePage _bookDepoHome = new BookDepoHomePage();
        private readonly SearchResultPage _searchResultPage = new SearchResultPage();
        private readonly BookTitles.Book _bookToBuy = Books.GetBook(BookTitles.BookTitle.TheLittlePrince);

        [Given(@"I am on the bookdepository homepage")]
        public void GivenIAmOnTheBookdepositoryHomepage()
        {
            GlobalSteps.GoToBookDepoHome();
            GlobalSteps.WaitForPageToLoad();
        }
        
        //----------- Search for book -------------//

        [Given(@"the search bar is available")]
        public void GivenTheSearchBarIsAvailable()
        {
            Assert.True(_bookDepoHome.SearchBarIsAvaialble());
        }
        
        [When(@"I enter the book title and search")]
        public void WhenIEnterTheBookTitleAndSearch()
        {
            _bookDepoHome.SearchForBook(_bookToBuy.Title);
        }
        
        [Then(@"the book is displayed as search result")]
        public void ThenTheBookIsDisplayedAsSearchResult()
        {
            Assert.True(_searchResultPage.BooksAreFound(_bookToBuy.Title));
        }

        //----------- Add item to basket -------------//
        [Given(@"I added a book to my basket")]
        public void GivenIAddedABookToMyBasket()
        {
            
        }

        [Then(@"I can see the item-added notfication")]
        public void ThenICanSeeTheItem_AddedNotfication()
        {
            
        }

        [When(@"I choose to go to checkout")]
        public void WhenIChooseToGoToCheckout()
        {
            
        }

        [Then(@"I can see my basket")]
        public void ThenICanSeeMyBasket()
        {
            
        }

        [Then(@"I can see the added item, its price and the total")]
        public void ThenICanSeeTheAddedItemItsPriceAndTheTotal()
        {
            
        }

    }
}
