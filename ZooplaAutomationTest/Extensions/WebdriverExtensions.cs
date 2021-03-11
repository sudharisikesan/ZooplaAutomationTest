using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace ZooplaAutomationTest.Extensions
{
	public static class WebdriverExtensions
	{
		public static void WaitUntilClickableAndClick(this IWebElement webElement, IWebDriver driver)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement)).Click();
		}

        public static bool WaitElementToBeDisplayed(this IWebElement webElement, IWebDriver driver, int timeoutsec = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutsec));
                wait.Until(d => webElement.Displayed);

                return webElement.Displayed;
            }

            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TargetInvocationException)
            {
                return false;
            }
        }
    }
}
