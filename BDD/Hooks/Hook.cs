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
        private IWebDriver _webdriver;

        [BeforeScenario]
        public void SetUp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webdriver = new ChromeDriver();
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Window.Maximize();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(_webdriver); //using a container, I'm saving webdriver dependency so I can inject it further in the code
        }
        
        [AfterScenario]
        public void TearDown()
        {
            var webdriver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>(); //injecting webdriver dependency
            webdriver.Quit();        
        }
    }
}