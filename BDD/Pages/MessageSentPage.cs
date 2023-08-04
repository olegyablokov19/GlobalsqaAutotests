using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class MessageSentPage
{
    private IWebDriver _webdriver;
    private SamplePageTestPage _samplePageTestPage;
    private ScenarioContext _scenarioContext;

    public MessageSentPage(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _samplePageTestPage = new SamplePageTestPage(_scenarioContext);
    }

    private By SubmittedFormLocator => By.Id("contact-form-2599");
    private IWebElement SubmittedForm => _webdriver.FindElement(SubmittedFormLocator);

    public void AssertInfoIsCorrect(SampleData sampleData)
    {
        SubmittedForm.Text.Should()
            .ContainAll(new List<string>
            {
                sampleData.Name,
                sampleData.Email,
                sampleData.Website,
                sampleData.Comment,
                sampleData.AutomationTesting,
                sampleData.ManualTesting,
                sampleData.PostGraduateEducation 
            });
    }
}