using System;
using Cin7Test.Infrastructure;
using Framework.DataModel.Cin7Sales;
using Framework.PageModel.BookDepo;
using Framework.PageModel.Cin7Sales;
using TechTalk.SpecFlow;
using Xunit;

namespace Cin7Test.StepDefinitions
{
    [Binding, Scope(Feature = "CreateSalesTest")]
    public class CreateSalesTestSteps : Steps
    {
        private readonly CreateSalesPage _createSalesPage = new CreateSalesPage();
        private readonly Pants.PantsAttr _bluePants = PantsFactory.GetPants(Pants.PantsTypeIndex.BluePants);
        private readonly Pants.PantsAttr _redPants = PantsFactory.GetPants(Pants.PantsTypeIndex.RedPants);
        private readonly Pants.PantsAttr _greenPants = PantsFactory.GetPants(Pants.PantsTypeIndex.GreenPants);
        private readonly Pants.PantsAttr _greyPants = PantsFactory.GetPants(Pants.PantsTypeIndex.GreyPants);
        private readonly SalesPage _salesPage = new SalesPage();

        [Given(@"I am on the Create Sales page")]
        public void GivenIAmOnTheCreateSalesPage()
        {
            GlobalSteps.GoToCin7CreateSales();
            GlobalSteps.WaitForPageToLoad("Create");
            _createSalesPage.InitProductIdSelector(_redPants);
        }

        //--------- Scenarios: Create a Blue Pants sale ---------------//
        [Given(@"I have chosen Blue Pants to make sales")]
        public void GivenIHaveChosenBluePantsToMakeSales()
        {
            _createSalesPage.SelectPantsProduct(_bluePants);
        }

        [When(@"I press to create blue-pants sales")]
        public void WhenIPressToCreateBluePantsSales()
        {
            _createSalesPage.PressToCreateSales(_bluePants);
        }

        [Then(@"I can see the blue-pants sales records on the sales page")]
        public void ThenICanSeeTheBlue_PantsSalesRecordsOnTheSalesPage()
        {
            GlobalSteps.WaitForPageToLoad("Index");
            Assert.True(_salesPage.SalesIsCreated(_bluePants), "Sales is not created!");
            Assert.True(_salesPage.SalesIsCorrectlyCalculated(_bluePants), "Discount Price or Total Price was incorrect!");
        }

        //--------- Scenarios: Create a Red Pants sale ---------------//
        [Given(@"I have chosen Red Pants to make sales")]
        public void GivenIHaveChosenRedPantsToMakeSales()
        {
            _createSalesPage.SelectPantsProduct(_redPants);
        }

        [When(@"I press to create red-pants sales")]
        public void WhenIPressToCreateRedPantsSales()
        {
            _createSalesPage.PressToCreateSales(_redPants);
        }

        [Then(@"I can see the red-pants sales records on the sales page")]
        public void ThenICanSeeTheRed_PantsSalesRecordsOnTheSalesPage()
        {
            GlobalSteps.WaitForPageToLoad("Index");
            Assert.True(_salesPage.SalesIsCreated(_redPants), "Sales is not created!");
            Assert.True(_salesPage.SalesIsCorrectlyCalculated(_redPants), "Discount Price or Total Price was incorrect!");
        }

        //--------- Scenarios: Create a Green Pants sale ---------------//
        [Given(@"I have chosen Green Pants to make sales")]
        public void GivenIHaveChosenGreenPantsToMakeSales()
        {
            _createSalesPage.SelectPantsProduct(_greenPants);
        }

        [When(@"I press to create green-pants sales")]
        public void WhenIPressToCreateGreenPantsSales()
        {
            _createSalesPage.PressToCreateSales(_greenPants);
        }

        [Then(@"I can see the green-pants sales records on the sales page")]
        public void ThenICanSeeTheGreen_PantsSalesRecordsOnTheSalesPage()
        {
            GlobalSteps.WaitForPageToLoad("Index");
            Assert.True(_salesPage.SalesIsCreated(_greenPants), "Sales is not created!");
            Assert.True(_salesPage.SalesIsCorrectlyCalculated(_greenPants), "Discount Price or Total Price was incorrect!");
        }

        //--------- Scenarios: Create a Grey Pants sale ---------------//
        [Given(@"I have chosen Grey Pants to make sales")]
        public void GivenIHaveChosenGreyPantsToMakeSales()
        {
            _createSalesPage.SelectPantsProduct(_greyPants);
        }

        [When(@"I press to create grey-pants sales")]
        public void WhenIPressToCreateGreyPantsSales()
        {
            _createSalesPage.PressToCreateSales(_greyPants);
        }

        [Then(@"I can see the grey-pants sales records on the sales page")]
        public void ThenICanSeeTheSalesRecordsOnTheSalesPage()
        {
            GlobalSteps.WaitForPageToLoad("Index");
            Assert.True(_salesPage.SalesIsCreated(_greyPants), "Sales is not created!");
            Assert.True(_salesPage.SalesIsCorrectlyCalculated(_greyPants), "Discount Price or Total Price was incorrect!");
        }
    }
}
