using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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

        public IWebDriver Init(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new ChromeDriver();
                case "Edge":
                    new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new EdgeDriver();
                case "Firefox":
                    //new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new FirefoxDriver();
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new ChromeDriver();
            }

            //That could be used to run tests on Lambda Test or other cross-browser testing platform

            //ChromeOptions capabilities = new ChromeOptions();
            //capabilities.BrowserVersion = "114.0";
            //Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            //ltOptions.Add("username", Variables.Username);
            //ltOptions.Add("accessKey", Variables.AccessKey);
            //ltOptions.Add("platformName", "MacOS Catalina");
            //ltOptions.Add("resolution", "2048x1536");
            //ltOptions.Add("project", "GlobalsQA");
            //ltOptions.Add("build", "SomeBuild");
            //ltOptions.Add("w3c", true);
            //ltOptions.Add("plugin", "c#-nunit");
            //capabilities.AddAdditionalOption("LT:Options", ltOptions);
            //_driver = new RemoteWebDriver(new Uri("https://" + Variables.Username + ":" + Variables.AccessKey + "@hub.lambdatest.com/wd/hub"), capabilities.ToCapabilities());
        }
    }
}
