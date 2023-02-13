using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTests
{
    public class SelectDropDownMenuActions
    {
        private IWebDriver _webdriver;
        private WebDriverWait _wait;
        private SelectDropDownMenuPage _selectDropDownMenuPage;
        public SelectDropDownMenuActions(IWebDriver webdriver)
        {
                _webdriver = webdriver;
                _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
                _selectDropDownMenuPage = new SelectDropDownMenuPage(_webdriver);
        }
        public int GetNumberOfOptions()
        {
            return _selectDropDownMenuPage.GetDropDownOptions().Count;
        }
    }
}