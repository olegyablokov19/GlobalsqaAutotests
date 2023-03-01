using BDD.Hooks;
using BDD.Pages;
using FluentAssertions;
using OpenQA.Selenium;

namespace BDD.Steps;

[Binding]
public class SubmittingDataStepDefinitions
{
    private IWebDriver _webdriver;
    private SampleData _sampleData;
    public SubmittingDataStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
    }
    private SamplePageTestPage _samplePageTestPage => new SamplePageTestPage(_webdriver);
    private MessageSentPage _messageSentPage => new MessageSentPage(_webdriver);

    [When(@"I fill all fields")]
    public void WhenIFillAllFields()
    {
        _sampleData = SampleData.CreateSampleData("Oleg", "myemail@mail.com", "https://www.google.de/", 6);
        _samplePageTestPage.FillFields(_sampleData);
    }

    [When(@"click Submit button")]
    public void WhenClickSubmitButton()
    {
        _samplePageTestPage.ClickSubmit();
    }

    [Then(@"the correct information is displayed")]
    public void ThenTheCorrectInformationIsDisplayed()
    {
        _messageSentPage.AssertInfoIsCorrect(_sampleData);
    }
}