using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using ZooplaAutomationTest.Context;
using ZooplaAutomationTest.Pages;
using ZooplaAutomationTest.Steps;

namespace ZooplaAutomationTest.Hooks
{
	[Binding]
	public class ScenarioHooks : BaseSteps
	{
		private AlertsAndSearchesPage _alertsAndSearchesPage;
		private DashboardPage _dashboardPage;

		public ScenarioHooks(CustomTestContext testContext) : base(testContext)
		{
			_testContext = testContext;
			_alertsAndSearchesPage = new AlertsAndSearchesPage(driver);
			_dashboardPage = new DashboardPage(driver);
		}
		[AfterScenario("@ClearAlert")]
		public void AfterScenario()
		{
			Actions action = new Actions(driver);
			action.MoveToElement(_dashboardPage.MyZoopla).
			Build().Perform();
			_dashboardPage.AlertsAndSearchesMenu.Click();
			_alertsAndSearchesPage.DeleteAlertButton.Click();
		}
	}
}
