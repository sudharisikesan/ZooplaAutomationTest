using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;
using ZooplaAutomationTest.Context;
using ZooplaAutomationTest.Extensions;
using ZooplaAutomationTest.Pages;


namespace ZooplaAutomationTest.Steps
{
    [Binding]
    public class CreateEmailUpdateSteps : BaseSteps
    {
        private DashboardPage _dashboardPage;
        private SignInPage _signInPage;
        private PropertySearchResultPage _propertySearchResultPage;
        private AlertsAndSearchesPage _alertsAndSearchesPage;

        public CreateEmailUpdateSteps(CustomTestContext testContext) : base(testContext)
        {
            _testContext = testContext;
            _dashboardPage = new DashboardPage(driver);
            _signInPage = new SignInPage(driver);
            _propertySearchResultPage = new PropertySearchResultPage(driver);
            _alertsAndSearchesPage = new AlertsAndSearchesPage(driver);
        }

        [Given(@"User is on Zoopla Dashboard")]
        public void GivenUserIsOnZooplaDashboard()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("baseUrl"));
            _dashboardPage.AcceptCookie.WaitUntilClickableAndClick(driver);

        }
        
        [Given(@"User is successfully signed into Zoopla account")]
        public void GivenUserIsSuccessfullySignedIntoZooplaAccount()
        {
            _dashboardPage.SignIn.WaitUntilClickableAndClick(driver);
            _signInPage.EmailId.SendKeys(ConfigurationManager.AppSettings.Get("emailAddress"));
            _signInPage.Password.SendKeys(ConfigurationManager.AppSettings.Get("password"));
            _signInPage.SignInSubmit.WaitUntilClickableAndClick(driver);
        }
        
        [When(@"User fills all required fields for property search")]
        public void WhenUserFillsAllRequiredFieldsForPropertySearch()
        {
            _dashboardPage.ToRent.WaitUntilClickableAndClick(driver);
            _dashboardPage.SearchLocation.SendKeys("London");
            _dashboardPage.SearchLocation.Click();
            var minPrice = _dashboardPage.MinPrice;
            var minPriceSelect = new SelectElement(minPrice);
            minPriceSelect.SelectByText("£800 pcm");
            var maxPrice = _dashboardPage.MaxPrice;
            var maxPriceSelect = new SelectElement(maxPrice);
            maxPriceSelect.SelectByText("£1,000 pcm");
            var minBeds = _dashboardPage.MinBeds;
            var minBedsSelect = new SelectElement(minBeds);
            minBedsSelect.SelectByText("1+");
        }
        
        [When(@"User submits the details to search for matching properties")]
        public void WhenUserSubmitsTheDetailsToSearchForMatchingProperties()
        {
            _dashboardPage.SearchSubmitProp.WaitUntilClickableAndClick(driver);
        }
        
        [When(@"User clicks on Create email alert")]
        public void WhenUserClicksOnCreateEmailAlert()
        {
            _propertySearchResultPage.CreateEmailAlert.WaitUntilClickableAndClick(driver);
        }
        
        [Then(@"Email alert should be successfully created for user")]
        public void ThenEmailAlertShouldBeSuccessfullyCreatedForUser()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
            Assert.IsTrue(_propertySearchResultPage.EmailAlertConfirmationText.Text.Equals("Success! Your email alert has been created"));
            _propertySearchResultPage.ManageEmailAlert.WaitUntilClickableAndClick(driver);
            Thread.Sleep(1000);
            var emailFrequency = _alertsAndSearchesPage.EmailFrequency;
            var emailFrequencySelect = new SelectElement(emailFrequency);
            emailFrequencySelect.SelectByIndex(1);
        }
    }
}
