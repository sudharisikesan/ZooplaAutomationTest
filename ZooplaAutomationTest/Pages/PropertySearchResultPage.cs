using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class PropertySearchResultPage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By CreateEmailAlertLocator = By.LinkText("Create email alert");
		private By EmailAlertConfirmationTextLocator = By.CssSelector("[class='css-1w9ifi4-Heading4-StyledHeading ed4gf0w4']");
		private By FirstResultTitleLocator = By.XPath("//body/div[3]/div[2]/div[1]/div[4]/section[1]/a[1]/div[1]/h3[1]");
		private By ManageEmailAlertLocator = By.XPath("//a[contains(text(),'Manage my email alerts')]");
		private By FirstResultLocator = By.CssSelector("a:nth-of-type(1) img[role='presentation']");
		private By SaveSearchLocator = By.LinkText("Save this search");
		private By CloseConfirmationLocator = By.XPath("//body/div[7]/div[1]/div[1]/button[1]/*[1]");
		


		#endregion

		public PropertySearchResultPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement CreateEmailAlert => driver.FindElement(CreateEmailAlertLocator);
		public IWebElement EmailAlertConfirmationText => driver.FindElement(EmailAlertConfirmationTextLocator);
		public IWebElement ManageEmailAlert => driver.FindElement(ManageEmailAlertLocator);
		public IWebElement SearchFirstResult => driver.FindElement(FirstResultLocator);
		public IWebElement SaveSearchResult => driver.FindElement(SaveSearchLocator);
		public IWebElement CloseConfirmation => driver.FindElement(CloseConfirmationLocator);
		public IWebElement FirstResultTitle => driver.FindElement(FirstResultTitleLocator);
	}
}