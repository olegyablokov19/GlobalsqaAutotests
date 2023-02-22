using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD.Pages
{
    public class SelectDropDownMenuPage
    {
        private readonly IWebDriver _webdriver;
        public SelectDropDownMenuPage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        private By CountryDropDownLocator =>
            By.XPath("//select//option");
        private IReadOnlyCollection<IWebElement> CountryDropDown => _webdriver.FindElements(CountryDropDownLocator);
        public int GetDropDownOptionsCount() => CountryDropDown.Count;
    }
}