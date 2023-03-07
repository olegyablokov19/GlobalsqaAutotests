using BDD.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Steps;

[Binding]
public sealed class CountryDropdownStepDefinitions
{
    private IWebDriver _webdriver;
    private WebDriverWait _wait;
    private SelectDropDownMenuPage _selectDropDownMenuPage;
    private const int ExpectedNumberOfOptions = 249;
    private int _actualNumberOfOptions;
    public CountryDropdownStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
        _selectDropDownMenuPage = new SelectDropDownMenuPage(_webdriver);
    }

    [Given(@"I've opened ""(.*)"" page")]
    public void GivenIOpenedThePage(string page)
    {
        var url = page switch
        {
            "Select Drop Down Menu" => Url.SelectDropDownUrl,
            "Sample Page Test" => Url.SubmitDataUrl,
            "Progress Bar" => Url.ProgressBar,
            _ => null
        };
        _webdriver.Navigate().GoToUrl("https://www.globalsqa.com" + url);
    }

    [When("I open the Country dropdown")]
    public void WhenIOpenTheCountryDropdown()
    {
        _actualNumberOfOptions = _selectDropDownMenuPage.GetDropDownOptionsCount();
    }
    
    [Then("the number of options is correct")]
    public void ThenTheNumberOfOptionsIsCorrect()
    {
        _actualNumberOfOptions.Should().Be(ExpectedNumberOfOptions);
    }
}