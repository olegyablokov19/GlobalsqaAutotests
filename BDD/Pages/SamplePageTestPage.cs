﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD.Pages;

public class SamplePageTestPage
{
    private IWebDriver _webdriver;

    public SamplePageTestPage(IWebDriver webdriver)
    {
        _webdriver = webdriver;
    }
    
    private By NameFieldLocator => By.Id("g2599-name");
    private By EmailFieldLocator => By.Id("g2599-email");
    private By WebsiteFieldLocator => By.Id("g2599-website");
    private By ExperienceDropdownLocator => By.Id("g2599-experienceinyears");
    private By FunctionalTestingCheckboxLocator => By.XPath("//input[@value='Functional Testing']");
    private By AutomationTestingCheckboxLocator => By.XPath("//input[@value='Automation Testing']");
    private By ManualTestingCheckboxLocator => By.XPath("//input[@value='Manual Testing']");
    private By GraduateRadiobuttonLocator => By.XPath("//input[@value='Graduate']");
    private By PostGraduateRadiobuttonLocator => By.XPath("//input[@value='Post Graduate']");
    private By OtherRadiobuttonLocator => By.XPath("//input[@value='Other']");
    private By CommentFieldLocator => By.Id("contact-form-comment-g2599-comment");
    private By SubmitButtonLocator => By.CssSelector("#contact-form-2599 > form > p.contact-submit > button");

    private IWebElement NameField => _webdriver.FindElement(NameFieldLocator);
    private IWebElement EmailField => _webdriver.FindElement(EmailFieldLocator);
    private IWebElement WebsiteField => _webdriver.FindElement(WebsiteFieldLocator);
    private SelectElement ExperienceDropdown => new (_webdriver.FindElement(ExperienceDropdownLocator));
    private IWebElement FunctionalTestingCheckbox => _webdriver.FindElement(FunctionalTestingCheckboxLocator);
    private IWebElement AutomationTestingCheckbox => _webdriver.FindElement(AutomationTestingCheckboxLocator);
    private IWebElement ManualTestingCheckbox => _webdriver.FindElement(ManualTestingCheckboxLocator);
    private IWebElement GraduateRadiobutton => _webdriver.FindElement(GraduateRadiobuttonLocator);
    private IWebElement PostGraduateRadiobutton => _webdriver.FindElement(PostGraduateRadiobuttonLocator);
    private IWebElement OtherRadiobutton => _webdriver.FindElement(OtherRadiobuttonLocator);
    private IWebElement CommentField => _webdriver.FindElement(CommentFieldLocator);
    private IWebElement SubmitButton => _webdriver.FindElement(SubmitButtonLocator);
    private IJavaScriptExecutor _executor => (IJavaScriptExecutor) _webdriver;
    public void SelectExperienceOption(int years)
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
        NameField.SendKeys(sampleData.Name);
        EmailField.SendKeys(sampleData.Email);
        WebsiteField.SendKeys(sampleData.Website);
        SelectExperienceOption(sampleData.ExperienceInYears);
        _executor.ExecuteScript("arguments[0].click()", AutomationTestingCheckbox);
        _executor.ExecuteScript("arguments[0].click()", ManualTestingCheckbox);
        _executor.ExecuteScript("arguments[0].click()", GraduateRadiobutton);
        CommentField.SendKeys("Some Comment");
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }
}