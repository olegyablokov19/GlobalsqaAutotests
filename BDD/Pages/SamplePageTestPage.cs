using BDD.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class SamplePageTestPage
{
    private IWebDriver _webdriver;
    private IJavaScriptExecutor _executor => (IJavaScriptExecutor) _webdriver;
    private WebDriverWait _wait;
    public SamplePageTestPage(IWebDriver webdriver)
    {
        _webdriver = webdriver;
        _wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15));
    }
    
    private By NameFieldLocator => By.Id("g2599-name");
    private By EmailFieldLocator => By.Id("g2599-email");
    private By WebsiteFieldLocator => By.Id("g2599-website");
    private By ExperienceDropdownLocator => By.Id("g2599-experienceinyears");
    private By CommentFieldLocator => By.Id("contact-form-comment-g2599-comment");
    private By SubmitButtonLocator => By.CssSelector("#contact-form-2599 > form > p.contact-submit > button");
    
    private IWebElement NameField => _webdriver.FindElement(NameFieldLocator);
    private IWebElement EmailField => _webdriver.FindElement(EmailFieldLocator);
    private IWebElement WebsiteField => _webdriver.FindElement(WebsiteFieldLocator);
    private SelectElement ExperienceDropdown => new (_webdriver.FindElement(ExperienceDropdownLocator));
    private IWebElement FindCheckbox(string value) => _webdriver.FindElement(By.XPath($"//input[@value='{value}']"));
    private IWebElement CommentField => _webdriver.FindElement(CommentFieldLocator);
    private IWebElement SubmitButton => _webdriver.FindElement(SubmitButtonLocator);
    private void SelectExperienceOption(int years)
    {
        switch (years)
        {
            case <= 0:
                ExperienceDropdown.SelectByText("0-1");
                break;
            case > 1 and <= 3:
                ExperienceDropdown.SelectByText("1-3");
                break;
            case > 3 and <= 5:
                ExperienceDropdown.SelectByText("3-5");
                break;
            case > 5 and <= 7:
                ExperienceDropdown.SelectByText("5-7");
                break;
            case > 7 and <= 10:
                ExperienceDropdown.SelectByText("7-10");
                break;
            case > 10:
                ExperienceDropdown.SelectByText("10+");
                break;
        }
    }

    public void FillFields(SampleData sampleData)
    {
        _executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        NameField.SendKeys(sampleData.Name);
        EmailField.SendKeys(sampleData.Email);
        WebsiteField.SendKeys(sampleData.Website);
        SelectExperienceOption(sampleData.ExperienceInYears);
        //_executor.ExecuteScript("window.scrollBy(0,400)"); //deprecated - wrote a new JS script (line 72) which hides the ad
        CheckTheCheckbox(sampleData.AutomationTesting);
        CheckTheCheckbox(sampleData.ManualTesting);
        CheckTheCheckbox(sampleData.PostGraduateEducation);
        CommentField.SendKeys("Some Comment");
        //_executor.ExecuteScript("window.scrollBy(0,500)"); //deprecated - wrote a new JS script (line 72) which hides the ad
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    private void CheckTheCheckbox(string text)
    {
        try
        {
            FindCheckbox(text).Click();
        }
        catch (ElementClickInterceptedException)
        {
            _executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                    "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        }
    }
}