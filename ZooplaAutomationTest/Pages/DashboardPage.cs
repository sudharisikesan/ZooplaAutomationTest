using OpenQA.Selenium;

namespace ZooplaAutomationTest.Pages
{
	class DashboardPage
	{
		private readonly IWebDriver driver;

		#region Locators
		private By SignInLocator = By.LinkText("Sign in");
		private By ToRentLocator = By.Id("search-tabs-to-rent");
		private By SearchLocationLocator = By.Id("search-input-location");
		private By MinPriceLocator = By.Id("rent_price_min_per_month");
		private By MaxPriceLocator = By.Id("rent_price_max_per_month"); 
		private By MinBedsLocator = By.Id("beds_min");
		private By SearchSubmitPropLocator = By.Id("search-submit");
		private By AcceptCookieLocator = By.XPath("//*[@id='cookie-consent-form']/div/div/div/button[2]");
		private By MyZooplaLocator = By.LinkText("My Zoopla");
		private By AlertsAndSearchesLocator = By.CssSelector("[class='css-1oboy4t-LogoWrapper exf84yl3'] li:nth-of-type(2) .css-l6ka86-Wrapper-IconAndText");
		private By HousePriceLocator = By.LinkText("House prices");
		private By ForSaleLocator = By.Id("search-tabs-for-sale");
		#endregion

		public DashboardPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public IWebElement SignIn => driver.FindElement(SignInLocator);
		public IWebElement ToRent => driver.FindElement(ToRentLocator);
		public IWebElement SearchLocation => driver.FindElement(SearchLocationLocator);
		public IWebElement MinPrice => driver.FindElement(MinPriceLocator);
		public IWebElement MaxPrice => driver.FindElement(MaxPriceLocator);
		public IWebElement MinBeds => driver.FindElement(MinBedsLocator);
		public IWebElement SearchSubmitProp => driver.FindElement(SearchSubmitPropLocator);
		public IWebElement AcceptCookie => driver.FindElement(AcceptCookieLocator);
		public IWebElement MyZoopla => driver.FindElement(MyZooplaLocator);
		public IWebElement AlertsAndSearchesMenu => driver.FindElement(AlertsAndSearchesLocator);
		public IWebElement HousePriceLink => driver.FindElement(HousePriceLocator);
		public IWebElement ForSaleLink => driver.FindElement(ForSaleLocator);
	}
}
