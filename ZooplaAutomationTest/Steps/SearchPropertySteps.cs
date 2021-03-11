using System;
using TechTalk.SpecFlow;
using ZooplaAutomationTest.Context;
using ZooplaAutomationTest.Pages;
using ZooplaAutomationTest.Extensions;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;

namespace ZooplaAutomationTest.Steps
{
    [Binding]
    public class SearchPropertySteps : BaseSteps
    {
        private DashboardPage _dashboardPage;
        private ForSalePage _forSalePage;
        private PropertySearchResultPage _propertySearchResultPage;
        private AlertsAndSearchesPage _alertsAndSearchesPage;
        private HousePricePage _housePricePage;
        private PropertyDetailsPage _propertyDetailsPage;
        private String _postcode;


        public SearchPropertySteps(CustomTestContext testContext) : base(testContext)
        {
            _testContext = testContext;
            _dashboardPage = new DashboardPage(driver);
            _forSalePage = new ForSalePage(driver);
            _propertySearchResultPage = new PropertySearchResultPage(driver);
            _alertsAndSearchesPage = new AlertsAndSearchesPage(driver);
            _housePricePage = new HousePricePage(driver);
            _propertyDetailsPage = new PropertyDetailsPage(driver);

        }

        [Given(@"User goes to For sale properties page")]
        public void GivenUserGoesToForSalePropertiesPage()
        {
            _dashboardPage.ForSaleLink.WaitUntilClickableAndClick(driver);
        }
        
        [Given(@"User Enters postcode as ""(.*)""")]
        [When(@"User Enters postcode ""(.*)""")]
        public void GivenUserEntersPostcodeAs(string postcode)
        {
            _postcode = postcode;
            _forSalePage.SearchLocationInput.SendKeys(postcode);
            _forSalePage.SearchLocationInput.Click();
        }
        
        [Given(@"User Inputs in the advanved keyword search ""(.*)""")]
        public void GivenUserInputsInTheAdvanvedKeywordSearch(string keyword)
        {
            _forSalePage.AdvancedSearchLink.WaitUntilClickableAndClick(driver);
            _forSalePage.AdvancedSearchKeyword.SendKeys(keyword);
        }
        
        [Given(@"User submits the data to search for properties")]
        [When(@"User submits the data to search for properties")]
        public void UserSubmitsTheDataToSearchForPropertieS()
        {
            _forSalePage.SearchLocationSubmit.WaitUntilClickableAndClick(driver);
        }

        [When(@"User saves the search")]
        public void WhenUserSavesTheSearch()
        {
            _propertySearchResultPage.SaveSearchResult.WaitUntilClickableAndClick(driver);
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
            Assert.IsTrue(_propertySearchResultPage.EmailAlertConfirmationText.Text.Equals("Success! Your search has been saved"));
            _propertySearchResultPage.CloseConfirmation.WaitUntilClickableAndClick(driver);
        }

        [When(@"User navigates to AlertAndSearches from My Zoopla")]
        public void WhenUserNavigatesToAlertAndSearchesFromMyZoopla()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(_dashboardPage.MyZoopla).
            Build().Perform();
            _dashboardPage.AlertsAndSearchesMenu.WaitUntilClickableAndClick(driver);
        }

        [When(@"User navigates to House Price page")]
        public void WhenUserNavigatesToHousePricePage()
        {
            _dashboardPage.HousePriceLink.WaitUntilClickableAndClick(driver);
        }

        [When(@"User Enters House postcode ""(.*)""")]
        public void WhenUserEntersHousePostcode(string postcode)
        {
            _postcode = postcode;
            _housePricePage.HouseLocationInput.SendKeys(postcode);
            Thread.Sleep(2000);
            driver.FindElement(_housePricePage.SearchResultLocator(postcode)).WaitUntilClickableAndClick(driver);
        }

        [When(@"User submits data to search for properties within that postcode")]
        public void WhenUserSubmitsDataToSearchForPropertiesWithinThatPostcode()
        {
            _housePricePage.HouseLocationSearch.WaitUntilClickableAndClick(driver);
        }

        [When(@"User Inputs in the advanved keyword search ""(.*)""")]
        public void WhenUserInputsInTheAdvanvedKeywordSearch(string keyword)
        {
            _forSalePage.AdvancedSearchLink.WaitUntilClickableAndClick(driver);
            _forSalePage.AdvancedSearchKeyword.SendKeys(keyword);
        }

        [Then(@"User should be able to see the recently saved search")]
        public void ThenUserShouldBeAbleToSeeTheRecentlySavedSearch()
        {
            Assert.AreEqual(_postcode,_alertsAndSearchesPage.SavedSearchAddress.Text);
            _alertsAndSearchesPage.ViewSearchAddress.WaitUntilClickableAndClick(driver);
            Assert.IsTrue(_alertsAndSearchesPage.ResultTitle.Text.Contains("London SE1"));
        }

        [Then(@"User should be able to see the result of search matching the input postcode")]
        public void ThenUserShouldBeAbleToSeeTheResultOfSearchMatchingTheInputPostcode()
        {
            Assert.AreEqual(_postcode, _propertySearchResultPage.FirstResultTitle.Text.Substring(","));
        }

        [Then(@"User should see search results with garage")]
        public void ThenUserShouldSeeSearchResultsWithGarage()
        {
            _propertySearchResultPage.SearchFirstResult.WaitUntilClickableAndClick(driver);
           Assert.IsTrue(_propertyDetailsPage.PropertyFeatures.Text.Contains("Garage"));
        }


    }
}
