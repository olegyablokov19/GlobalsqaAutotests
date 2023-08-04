using BDD.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD.Pages
{
    public class SelectDropDownMenuPage
    {
        private readonly IWebDriver _webdriver;
        private ScenarioContext _scenarioContext;
        public SelectDropDownMenuPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        }
        private By CountryDropDownLocator =>
            By.XPath("//select//option");
        private IReadOnlyCollection<IWebElement> CountryDropDown => _webdriver.FindElements(CountryDropDownLocator);
        public int GetDropDownOptionsCount() => CountryDropDown.Count;
    }
}