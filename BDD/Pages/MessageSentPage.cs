using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class MessageSentPage
{
    private IWebDriver _webdriver;
    private SamplePageTestPage _samplePageTestPage;
    public MessageSentPage(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _samplePageTestPage = new SamplePageTestPage(_webdriver);
    }

    private By SubmittedFormLocator => By.Id("contact-form-2599");
    private IWebElement SubmittedForm => _webdriver.FindElement(SubmittedFormLocator);

    public void AssertInfoIsCorrect(SampleData sampleData)
    {
        SubmittedForm.Text.Should()
            .Contain(sampleData.Name)
            .And.Contain(sampleData.Email)
            .And.Contain(sampleData.Website)
            .And.Contain(sampleData.Comment);
    }
}