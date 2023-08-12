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
    private ScenarioContext _scenarioContext;
    public SamplePageTestPage(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _webdriver = _scenarioContext.Get<IWebDriver>("webdriver");
    }
    
    private By NameFieldLocator => By.Id("g2599-name");
    private By EmailFieldLocator => By.Id("g2599-email");
    private By WebsiteFieldLocator => By.Id("g2599-website");
    private By ExperienceDropdownLocator => By.Id("g2599-experienceinyears");
    private By CommentFieldLocator => By.Id("contact-form-comment-g2599-comment");
    private By SubmitButtonLocator => By.XPath("//button[@type=\"submit\"]");
    private By ChooseFileButtonLocator => By.XPath("//input[@type=\"file\"]");
    
    private IWebElement NameField => _webdriver.FindElement(NameFieldLocator);
    private IWebElement EmailField => _webdriver.FindElement(EmailFieldLocator);
    private IWebElement WebsiteField => _webdriver.FindElement(WebsiteFieldLocator);
    private SelectElement ExperienceDropdown => new (_webdriver.FindElement(ExperienceDropdownLocator));
    private IWebElement FindCheckbox(string value) => _webdriver.FindElement(By.XPath($"//input[@value='{value}']"));
    private IWebElement CommentField => _webdriver.FindElement(CommentFieldLocator);
    private IWebElement SubmitButton => _webdriver.FindElement(SubmitButtonLocator);
    private IWebElement ChooseFileButton => _webdriver.FindElement(ChooseFileButtonLocator); 
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
        NameField.SendKeys(sampleData.Name);
        EmailField.SendKeys(sampleData.Email);
        WebsiteField.SendKeys(sampleData.Website);
        SelectExperienceOption(sampleData.ExperienceInYears);
        CheckTheCheckbox(sampleData.AutomationTesting);
        CheckTheCheckbox(sampleData.ManualTesting);
        CheckTheCheckbox(sampleData.PostGraduateEducation);
        CommentField.SendKeys(sampleData.Comment);
    }

    public void ClickSubmit()
    {
        SubmitButton.Click();
    }

    public void CheckTheCheckbox(string text)
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

    public void UploadFile()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;              
        string file = System.IO.Path.Combine(currentDirectory, @"..\..\..\Files\FileForUpload.jpg");  
        string filePath = Path.GetFullPath(file);  
        ChooseFileButton.SendKeys(filePath);
    }
}