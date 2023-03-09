using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class DownloadFilePage
{
    private IWebDriver _webdriver;
    private WebDriverWait _wait;
    private IJavaScriptExecutor _executor => (IJavaScriptExecutor)_webdriver;
    public DownloadFilePage(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
    }
    private By StartDownloadButtonLocator => By.CssSelector("#downloadButton");
    private By ProgressBarLocator => By.XPath("//*[@id=\"progressbar\"]");

    private By IframeLocator =>
        By.XPath(
            "//iframe[@class=\"demo-frame lazyloaded\"]");

    private By CloseButtonLocator => By.XPath("//button[@class=\"ui-button ui-corner-all ui-widget\"]");
    private IWebElement StartDownloadButton => _wait.Until(ExpectedConditions.ElementToBeClickable(StartDownloadButtonLocator));
    //private IWebElement ProgressBar => _wait.Until(ExpectedConditions.ElementToBeClickable(ProgressBarLocator));
    private IWebElement Iframe => _wait.Until(ExpectedConditions.ElementIsVisible(IframeLocator));
    private IWebElement CloseButton => _wait.Until(ExpectedConditions.ElementToBeClickable(CloseButtonLocator));
    public void ClickStartDownloadButton()
    {
        _executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
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
            _executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                    "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        }
        catch (StaleElementReferenceException)
        {
            CloseButton.Click();
        }
    }

    public Func<IWebDriver, IWebElement> WaitUntilDownloadIsComplete()
    {
        return (driver) =>
        {
            try
            {
                IWebElement element = driver.FindElement(ProgressBarLocator);
                if (element.GetAttribute("aria-valuenow").Equals("100"))
                {
                    return element;
                }
            }
            catch (NullReferenceException e)
            {
            }
            catch (StaleElementReferenceException r)
            {
                IWebElement element = driver.FindElement(ProgressBarLocator);
                if (element.GetAttribute("aria-valuenow").Equals("100"))
                {
                    return element;
                }
            }
            return null;
        };
    }
}