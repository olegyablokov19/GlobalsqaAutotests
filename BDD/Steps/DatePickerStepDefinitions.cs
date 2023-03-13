using BDD.Pages;
using FluentAssertions;
using OpenQA.Selenium;

namespace BDD.Steps;

[Binding]
public class DatePickerStepDefinitions
{
    private IWebDriver _webdriver;
    private DatePickerPage _datePickerPage;

    public DatePickerStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _datePickerPage = new DatePickerPage(_webdriver);
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
        _datePickerPage.ClickAnyDate(_webdriver);
    }

    [Then(@"the date is displayed")]
    public void ThenTheDateIsDisplayed()
    {
        _datePickerPage.GetDate().Should().NotBeNullOrEmpty();
    }
}