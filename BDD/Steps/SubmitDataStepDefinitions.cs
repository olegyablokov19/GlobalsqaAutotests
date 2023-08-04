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
    private ScenarioContext _scenarioContext;

    public SubmittingDataStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
    }
    private SamplePageTestPage _samplePageTestPage => new SamplePageTestPage(_scenarioContext);
    private MessageSentPage _messageSentPage => new MessageSentPage(_scenarioContext);

    [When(@"I fill all fields")]
    public void WhenIFillAllFields()
    {
        _samplePageTestPage.UploadFile();
        _sampleData = SampleData.CreateSampleData();
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