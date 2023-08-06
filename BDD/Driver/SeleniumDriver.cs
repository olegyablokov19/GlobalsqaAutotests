using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BDD.Driver
{
    public class SeleniumDriver
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "114.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", Variables.Username);
            ltOptions.Add("accessKey", Variables.AccessKey);
            ltOptions.Add("platformName", "MacOS Catalina");
            ltOptions.Add("resolution", "2048x1536");
            ltOptions.Add("project", "GlobalsQA");
            ltOptions.Add("build", "SomeBuild");
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-nunit");
            capabilities.AddAdditionalOption("LT:Options", ltOptions);
         
            var _driver = new RemoteWebDriver(new Uri("https://" + Variables.Username + ":" + Variables.AccessKey + "@hub.lambdatest.com/wd/hub"), capabilities.ToCapabilities());
            return _driver;
        }
    }
}
