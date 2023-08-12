using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class DatePickerPage
{
    private IWebDriver _webdriver;
    private WebDriverWait _wait;
    private ScenarioContext _scenarioContext;

    public DatePickerPage(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(3));
    }
    private By DateFieldLocator => By.XPath("//input[@id=\"datepicker\"]");
    private By IframeLocator => By.XPath("//iframe[@class=\"demo-frame lazyloaded\"]");
    private By CalendarLocator => By.Id("ui-datepicker-div");

    private IWebElement DateField => _wait.Until(x => x.FindElement(DateFieldLocator));
    private IWebElement Iframe => _wait.Until(x => x.FindElement(IframeLocator));

    public void ClickDateField()
    {
        _webdriver.SwitchTo().Frame(Iframe);
        DateField.Click();
    }

    public void WaitForCalendarToShow()
    {
        _wait.Until(x => x.FindElement(CalendarLocator).GetDomAttribute("style").Contains("display: block"));
    }

    public void ClickHighlightedDate()
    {
        var highlightedDate =
            _webdriver.FindElement(By.XPath("//a[@class=\"ui-state-default ui-state-highlight ui-state-hover\"]"));
        highlightedDate.Click();
    }

    public string GetDate()
    {
        var date = DateField.GetAttribute("value");
        return date;
    }
}