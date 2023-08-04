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
        public static string username = "oleg.yablokov19";
        public static string access_key = "onPaVaE6PJK4VEfBGTlhoovIAz9J3Jhp3kji4IEielQPbjb193";

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "112.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", username);
            ltOptions.Add("accessKey", access_key);
            ltOptions.Add("platformName", "MacOS Catalina");
            ltOptions.Add("resolution", "2048x1536");
            ltOptions.Add("project", "GlobalsQA");
            ltOptions.Add("build", "SomeBuild");
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-nunit");
            capabilities.AddAdditionalOption("LT:Options", ltOptions);
         
            var _driver = new RemoteWebDriver(new Uri("https://" + username + ":" + access_key + "@hub.lambdatest.com/wd/hub"), capabilities.ToCapabilities());
            return _driver;
        }
    }
}
