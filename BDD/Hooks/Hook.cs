using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BDD.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;

        [BeforeScenario]
        public void SetUp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            IWebDriver webdriver = new ChromeDriver();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            webdriver.Manage().Window.Maximize();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(webdriver);
        }
        
        [AfterScenario]
        public void TearDown()
        {
            var webdriver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>();
            webdriver.Quit();        
        }
    }
}