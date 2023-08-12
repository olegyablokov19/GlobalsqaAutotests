using BDD.Driver;
using BDD.Hooks;
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
    private ScenarioContext _scenarioContext;
    private SelectDropDownMenuPage _selectDropDownMenuPage;
    private const int ExpectedNumberOfOptions = 249;
    private int _actualNumberOfOptions;
    public CountryDropdownStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _selectDropDownMenuPage = new SelectDropDownMenuPage(_scenarioContext);
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
        Console.WriteLine("The number of options is " + _actualNumberOfOptions + " of " + ExpectedNumberOfOptions);
    }
}