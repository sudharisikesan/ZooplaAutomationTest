using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using ZooplaAutomationTest.Context;

namespace ZooplaAutomationTest.Hooks
{
	[Binding]
	public class WebdriverHooks
	{
		public readonly CustomTestContext _testContext;

		public WebdriverHooks(CustomTestContext testContext)
		{
			_testContext = testContext;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			var browser = ConfigurationManager.AppSettings.Get("browser");
			_testContext.driver = DetermineDriver(browser);
		}

        private static IWebDriver DetermineDriver(string driverName)
        {
            IWebDriver driver;

            var chromeOptions = new ChromeOptions();

            switch (driverName)
            {
                case "chrome":
                    chromeOptions.AddArgument("--incognito");
                    chromeOptions.AddArgument("start-maximized");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "chrome-headless":
                    chromeOptions.AddArgument("--headless");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new Exception("Unsupported driver");
            }
            return driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _testContext.driver.Dispose();
        }
    }
}
