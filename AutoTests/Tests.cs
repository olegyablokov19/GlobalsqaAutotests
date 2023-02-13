using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;

namespace AutoTests
{
    [TestFixture]
    public class SomeTest
    {
        private IWebDriver _webdriver;
        private SelectDropDownMenuActions _selectDropDownMenuActions;
        private readonly int _expectedNumberOfOptions = 249;

        [OneTimeSetUp]
        public void SetUp()
        {
            _webdriver = new ChromeDriver();
            _webdriver.Manage().Window.Maximize();
            _selectDropDownMenuActions = new SelectDropDownMenuActions(_webdriver);
        }

        [Test]
        public void CountNumberOfOptions()
        {
            _webdriver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/select-dropdown-menu/");
            var numberOfOptions = _selectDropDownMenuActions.GetNumberOfOptions();
            numberOfOptions.Should().Be(_expectedNumberOfOptions);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _webdriver.Quit();
        }
    }
}