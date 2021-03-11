using OpenQA.Selenium;
using ZooplaAutomationTest.Context;

namespace ZooplaAutomationTest.Steps
{
	public class BaseSteps
	{
		protected IWebDriver driver;
		public CustomTestContext _testContext;

        public BaseSteps(CustomTestContext customTestContext)
        {
            _testContext = customTestContext;
            driver = _testContext.driver;
        }
    }
}
