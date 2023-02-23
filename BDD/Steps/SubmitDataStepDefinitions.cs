using BDD.Hooks;
using BDD.Pages;
using OpenQA.Selenium;

namespace BDD.Steps;

[Binding]
public class SubmittingDataStepDefinitions
{
    private IWebDriver _webdriver;

    public SubmittingDataStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
    }
    private SamplePageTestPage _samplePageTestPage => new SamplePageTestPage(_webdriver);

    [When(@"I fill all fields")]
    public void WhenIFillAllFields()
    {
        var sampleData = SampleData.CreateSampleData("Oleg", "myemail@mail.com", "https://www.google.de/", 6);
        _samplePageTestPage.FillFields(sampleData);
    }

    [When(@"click Submit button")]
    public void WhenClickSubmitButton()
    {
        _samplePageTestPage.ClickSubmit();
    }

    [Then(@"the correct information is displayed")]
    public void ThenTheCorrectInformationIsDisplayed()
    {
        ScenarioContext.StepIsPending();
    }
}