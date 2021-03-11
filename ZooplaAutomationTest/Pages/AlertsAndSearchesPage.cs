using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class AlertsAndSearchesPage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By EmailFrequencyLocator = By.CssSelector("select[name='frequency']");
		private By DeleteAlertLocator = By.LinkText("Delete");
		private By SavedSearchAddressLocator = By.XPath("//body/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/form[1]/div[2]/h4[1]");
		private By ViewSearchLocator = By.LinkText("View");
		private By ResultTitleLocator = By.XPath("//h1[contains(text(),'Property for sale in Copper Row, London SE1')]");
		#endregion

		public AlertsAndSearchesPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement EmailFrequency => driver.FindElement(EmailFrequencyLocator);
		public IWebElement DeleteAlertButton => driver.FindElement(DeleteAlertLocator);
		public IWebElement SavedSearchAddress => driver.FindElement(SavedSearchAddressLocator);
		public IWebElement ViewSearchAddress => driver.FindElement(ViewSearchLocator);
		public IWebElement ResultTitle => driver.FindElement(ResultTitleLocator);

		public void DeleteAlert(IWebDriver driver)
		{
			DeleteAlertButton.Click();
		}
	}
}
