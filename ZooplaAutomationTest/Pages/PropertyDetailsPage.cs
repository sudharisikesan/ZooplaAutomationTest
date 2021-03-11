using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class PropertyDetailsPage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By PropertyFeaturesLocator = By.XPath("//body/main[@id='main-content']/div[2]/div[1]/div[3]/section[1]/div[2]/section[1]/ul[2]");
		#endregion

		public PropertyDetailsPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement PropertyFeatures => driver.FindElement(PropertyFeaturesLocator);
	}
}
