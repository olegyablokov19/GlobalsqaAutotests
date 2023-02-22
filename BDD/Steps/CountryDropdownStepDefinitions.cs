using BDD.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD.Steps;

[Binding]
public sealed class CountryDropdownStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private IWebDriver _webdriver;
    private SelectDropDownMenuPage _selectDropDownMenuPage;
    private const int ExpectedNumberOfOptions = 249;
    private int _actualNumberOfOptions;
    public CountryDropdownStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _selectDropDownMenuPage = new SelectDropDownMenuPage(_webdriver);
    }

    [Given("I've opened the page")]
    public void GivenIOpenedThePage()
    {
        _webdriver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/select-dropdown-menu/");
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