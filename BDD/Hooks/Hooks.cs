using System;
using BDD.Driver;
using BoDi;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace BDD.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;
        private SeleniumDriver _seleniumDriver;
        private IWebDriver _webdriver;
        private string path = Directory.GetCurrentDirectory();
        string currentDirectory = Directory.GetCurrentDirectory();
        public static Config Config;

        [BeforeScenario]
        public void SetUp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set<SeleniumDriver>(_seleniumDriver, "Selenium Driver");

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
            _webdriver = _scenarioContext.Get<IWebDriver>("webdriver"); //injecting webdriver dependency
            _webdriver.Quit();        
        }
    }
}