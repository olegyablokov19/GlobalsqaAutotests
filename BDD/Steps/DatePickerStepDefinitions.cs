using BDD.Pages;
using FluentAssertions;
using OpenQA.Selenium;

namespace BDD.Steps;

[Binding]
public class DatePickerStepDefinitions
{
    private IWebDriver _webdriver;
    private DatePickerPage _datePickerPage;
    private ScenarioContext _scenarioContext;

    public DatePickerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _datePickerPage = new DatePickerPage(_scenarioContext);
    }
    [When(@"I open the calendar")]
    public void WhenIOpenTheCalendar()
    {
        _datePickerPage.ClickDateField();
        _datePickerPage.WaitForCalendarToShow(_webdriver);
    }

    [When(@"choose a date")]
    public void WhenChooseADate()
    {
        _datePickerPage.ClickHighlightedDate(_webdriver);
    }

    [Then(@"the date is displayed")]
    public void ThenTheDateIsDisplayed()
    {
        _datePickerPage.GetDate().Should().NotBeNullOrEmpty();
    }
}