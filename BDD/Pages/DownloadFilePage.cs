using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class DownloadFilePage
{
    private IWebDriver _webdriver;
    private WebDriverWait _wait;
    private ScenarioContext _scenarioContext;

    private IJavaScriptExecutor _executor => (IJavaScriptExecutor)_webdriver;
    public DownloadFilePage(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
    }
    private By StartDownloadButtonLocator => By.CssSelector("#downloadButton");
    private By ProgressBarLocator => By.XPath("//*[@id=\"progressbar\"]");

    private By IframeLocator =>
        By.XPath(
            "//iframe[@class=\"demo-frame lazyloaded\"]");

    private By CloseButtonLocator => By.XPath("//button[@class=\"ui-button ui-corner-all ui-widget\"]");
    private IWebElement StartDownloadButton => _wait.Until(ExpectedConditions.ElementToBeClickable(StartDownloadButtonLocator));
    private IWebElement Iframe => _wait.Until(ExpectedConditions.ElementIsVisible(IframeLocator));
    private IWebElement CloseButton => _wait.Until(ExpectedConditions.ElementToBeClickable(CloseButtonLocator));
    public void ClickStartDownloadButton()
    {
        _webdriver.SwitchTo().Frame(Iframe);
        StartDownloadButton.Click();
    }

    public void ClickCloseButton()
    {
        try
        {
            CloseButton.Click();
        }
        catch (ElementClickInterceptedException)
        {
        }
        catch (StaleElementReferenceException)
        {
            CloseButton.Click();
        }
    }

    public void WaitUntilDownloadIsComplete()
    {
        IWebElement isDownloadComplete = _wait.Until(x => x.FindElement(ProgressBarLocator));
        _wait.Until(x => x.FindElement(ProgressBarLocator).GetAttribute("aria-valuenow") == "100");
    }
}