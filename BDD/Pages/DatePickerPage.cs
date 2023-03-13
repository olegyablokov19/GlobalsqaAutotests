using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class DatePickerPage
{
    private IWebDriver _webdriver;
    private WebDriverWait _wait;

    public DatePickerPage(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
    }
    private By DateFieldLocator => By.XPath("//input[@id=\"datepicker\"]");
    private By IframeLocator => By.XPath("//iframe[@class=\"demo-frame lazyloaded\"]");
    private By CalendarLocator => By.Id("ui-datepicker-div");

    private IWebElement DateField => _wait.Until(ExpectedConditions.ElementIsVisible(DateFieldLocator));
    private IWebElement Iframe => _wait.Until(ExpectedConditions.ElementIsVisible(IframeLocator));

    public void ClickDateField()
    {
        _webdriver.SwitchTo().Frame(Iframe);
        DateField.Click();
    }

    public void WaitForCalendarToShow(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        bool isCalendarShown(IWebDriver driver)
        {
            var calendar = driver.FindElement(CalendarLocator);
            var css = calendar.GetDomAttribute("style");
            return css.Contains("display: block");
            //display: block
        }

        wait.Until(isCalendarShown);
    }

    public void ClickAnyDate(IWebDriver driver)
    {
        var highlightedDate =
            driver.FindElement(By.XPath("//a[@class=\"ui-state-default ui-state-highlight ui-state-hover\"]"));
        highlightedDate.Click();
    }

    public string GetDate()
    {
        var value = DateField.GetAttribute("value");
        return value;
    }
}