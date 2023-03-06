using BDD.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD.Steps;

[Binding]
public class DownloadFileStepDefinitions
{
    private DownloadFilePage _downloadFilePage;
    private IWebDriver _webdriver;
    private WebDriverWait _wait;
    public DownloadFileStepDefinitions(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
        _downloadFilePage = new DownloadFilePage(_webdriver);
    }
    [When(@"I start downloading file")]
    public void WhenIStartDownloadingFile()
    {
        _downloadFilePage.ClickStartDownloadButton();
    }

    [Then(@"the downloading is completed")]
    public void ThenTheDownloadingIsCompleted()
    {
        _wait.Until(_downloadFilePage.WaitUntilDownloadIsComplete());
        _downloadFilePage.ClickCloseButton();
    }
}