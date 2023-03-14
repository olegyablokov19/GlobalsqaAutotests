using System;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace BDD.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;
        private IWebDriver _webdriver;
        private WebDriverWait _wait;
        private string path = Directory.GetCurrentDirectory();
        string currentDirectory = Directory.GetCurrentDirectory();
        public static Config Config;

        [BeforeScenario]
        public void SetUp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webdriver = new ChromeDriver();
            _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            _webdriver.Manage().Window.Maximize();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(_webdriver); //using a container, I'm saving webdriver dependency so I can inject it further in the code

            Config = new Config();
            var pathToJsonFile = currentDirectory + @"..\..\..\..\appsettings.json";
            ConfigurationBuilder builder = new ConfigurationBuilder();
            var configurationBuilder = builder.AddJsonFile(pathToJsonFile);
            var configuration = configurationBuilder.Build();
            configuration.Bind(Config);
        }
        
        [AfterScenario]
        public void TearDown()
        {
            var webdriver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>(); //injecting webdriver dependency
            webdriver.Quit();        
        }
    }
}