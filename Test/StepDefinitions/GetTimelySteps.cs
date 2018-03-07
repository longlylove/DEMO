using System;
using Framework.PageModel.GetTimely;
using TechTalk.SpecFlow;
using Test.Infrastructure;
using Xunit;

namespace Test.StepDefinitions
{
    [Binding]
    [Scope(Feature = "GetTimely")]
    public class GetTimelySteps: Steps
    {
        private static readonly GetTimelyHomePage GetTimelyHomePage = new GetTimelyHomePage();
        private static readonly FreeTrialSetUpPage FreeTrialSetUpPage = new FreeTrialSetUpPage();
        private static readonly LoginPage LoginPage = new LoginPage();
        private static readonly CalendarPage CalendarPage = new CalendarPage();

        [Given(@"I am on GetTimely homepage")]
        public void GivenIAmOnGetTimelyHomepage()
        {
            GlobalSteps.GoToGetTimelyHome();           
        }
        
        [Given(@"I fill in an email address")]
        public void GivenIFillInAnEmailAddress()
        {
            GetTimelyHomePage.FillInEmailEntry();
        }
        
        [Given(@"I click on the Login link")]
        public void GivenIClickOnTheLoginLink()
        {
            GetTimelyHomePage.GoToLoginpage();
        }
        
        [Given(@"the the login page is displayed")]
        public void GivenTheTheLoginPageIsDisplayed()
        {
            LoginPage.IsLoginPageDisplayed();
        }
        
        [When(@"I press the '(.*)' button")]
        public void WhenIPressTheButton(string p0)
        {
            GetTimelyHomePage.ClickToSignup();
        }
        
        [When(@"I fill in the login credentials")]
        public void WhenIFillInTheLoginCredentials()
        {
            LoginPage.FillInCredentials();
        }
        
        [When(@"I press '(.*)'")]
        public void WhenIPress(string p0)
        {
            LoginPage.ClickToLogin();
        }
        
        [Then(@"the sign up page is displayed showing '(.*)'")]
        public void ThenTheSignUpPageIsDisplayedShowing(string freeTrial)
        {
            var actual = FreeTrialSetUpPage.GetTrialBannerText().ToLower();
            Assert.True(actual.Contains(freeTrial.ToLower()),$"The banner does not contain expected Free Trial message.\nExpected: {freeTrial}\nActual: {actual}");
        }
        
        [Then(@"my calendar page is displayed")]
        public void ThenMyCalendarPageIsDisplayed()
        {
            GlobalSteps.WaitForPageToLoad("Calendar");
            CalendarPage.IsCalendarNavigationDisplayed();
        }
    }
}
