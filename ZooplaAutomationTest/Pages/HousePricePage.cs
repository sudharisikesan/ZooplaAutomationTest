using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class HousePricePage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By HouseLocationInputLocator = By.Id("search-input-location");
		private By HouseLocationSearchLocator = By.Id("search-submit");
		public By SearchResultLocator(string postcode) => By.XPath($"//*[contains(text(), '{postcode}')]");
		private By SearchInputWrapperLocator = By.CssSelector("#search-input-location-wrapper");
		private By SearchResultListLocator = By.CssSelector("[tabindex] [tabindex='-1']:nth-of-type(3) a");
		#endregion

		public HousePricePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement HouseLocationInput => driver.FindElement(HouseLocationInputLocator);
		public IWebElement HouseLocationSearch => driver.FindElement(HouseLocationSearchLocator);
		public IWebElement SearcInputWrapper => driver.FindElement(SearchInputWrapperLocator);
		public IWebElement SearchResultList => driver.FindElement(SearchResultListLocator);
	}
}
