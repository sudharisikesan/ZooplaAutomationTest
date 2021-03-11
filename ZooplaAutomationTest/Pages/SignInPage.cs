using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class SignInPage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By EmailIdLocator = By.Id("signin_email");
		private By PasswordLocator = By.Id("signin_password");
		private By SignInSubmitLocator = By.Id("signin_submit");
		#endregion

		public SignInPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement EmailId => driver.FindElement(EmailIdLocator);
		public IWebElement Password => driver.FindElement(PasswordLocator);
		public IWebElement SignInSubmit => driver.FindElement(SignInSubmitLocator);

	}
}
