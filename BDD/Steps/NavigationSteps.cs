using BDD.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private IWebDriver _webdriver;
        private ScenarioContext _scenarioContext;
        private IJavaScriptExecutor _executor => (IJavaScriptExecutor)_webdriver;

        public NavigationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webdriver = _scenarioContext.Get<SeleniumDriver>("Selenium Driver").Init();
            _scenarioContext.Set<IWebDriver>(_webdriver, "webdriver");
        }

        [Given(@"I've opened ""(.*)"" page")]
        public void GivenIOpenedThePage(string page)
        {
            var url = page switch
            {
                "Select Drop Down Menu" => Variables.SelectDropDownUrl,
                "Sample Page Test" => Variables.SubmitDataUrl,
                "Progress Bar" => Variables.ProgressBar,
                "Date Picker" => Variables.DatePicker,
                _ => null
            };
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Window.Maximize();
            _webdriver.Navigate().GoToUrl(url);

            Waiters.WaitForAdToClose(_webdriver, _executor);
        }
    }
}
