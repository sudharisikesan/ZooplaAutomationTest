using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class ForSalePage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By AdvancedSearchLocator = By.XPath("//span[contains(text(),'Advanced search options')]");
		private By AdvancedSearchKeywordLocator = By.Id("keywords");
		private By SearchLocationInputLocator = By.Id("search-input-location");
		private By SearchLocationSubmitLocator = By.Id("search-submit");
		#endregion


		public ForSalePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement AdvancedSearchLink => driver.FindElement(AdvancedSearchLocator);
		public IWebElement AdvancedSearchKeyword => driver.FindElement(AdvancedSearchKeywordLocator);
		public IWebElement SearchLocationInput => driver.FindElement(SearchLocationInputLocator);
		public IWebElement SearchLocationSubmit => driver.FindElement(SearchLocationSubmitLocator);
	}
}
