using AutoTests;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _webdriver;
    private SelectDropDownMenuActions _selectDropDownMenuActions;
    private SelectDropDownMenuPage _selectDropDownMenuPage;
    private const int ExpectedNumberOfOptions = 249;
    private int _actualNumberOfOptions;
    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = new ChromeDriver();
        _selectDropDownMenuActions = new SelectDropDownMenuActions(_webdriver);
        _selectDropDownMenuPage = new SelectDropDownMenuPage(_webdriver);
    }

    [Given("I've opened the page")]
    public void GivenIOpenedThePage()
    {
        _webdriver.Manage().Window.Maximize();
        _webdriver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/select-dropdown-menu/");
    }

    [When("I count the number of options in Country dropdown")]
    public void WhenICountTheNumberOfOptions()
    {
        _actualNumberOfOptions = _selectDropDownMenuActions.GetNumberOfOptions();
    }

    [Then("the number of options is correct")]
    public void ThenTheNumberOfOptionsIsCorrect()
    {
        _actualNumberOfOptions.Should().Be(ExpectedNumberOfOptions);
    }
}