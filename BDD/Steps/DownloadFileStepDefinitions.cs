using BDD.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD.Steps;

[Binding]
public class DownloadFileStepDefinitions
{
    private DownloadFilePage _downloadFilePage;
    private ScenarioContext _scenarioContext;
    private IWebDriver _webdriver;
    public DownloadFileStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _downloadFilePage = new DownloadFilePage(_scenarioContext);
    }
    [When(@"I start downloading file")]
    public void WhenIStartDownloadingFile()
    {
        _downloadFilePage.ClickStartDownloadButton();
    }

    [Then(@"the downloading is completed")]
    public void ThenTheDownloadingIsCompleted()
    {
        _downloadFilePage.WaitUntilDownloadIsComplete();
        _downloadFilePage.ClickCloseButton();
    }
}