using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTests
{
    public class SelectDropDownMenuPage
    {
        private IWebDriver _webdriver;
        private WebDriverWait _wait;
        public SelectDropDownMenuPage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
            _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
        }
        private By CountryDropDownLocator =>
            By.CssSelector("#post-2646 > div.twelve.columns > div > div > div > p > select");
        private SelectElement CountryDropDownSelect => new SelectElement(_wait.Until(x => x.FindElement(CountryDropDownLocator)));
        public IList<IWebElement> GetDropDownOptions() => CountryDropDownSelect.Options;
    }
}