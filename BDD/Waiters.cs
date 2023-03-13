using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD;

public class Waiters
{
    public static void WaitForAdToClose(IWebDriver webdriver, IJavaScriptExecutor executor)
    {
        var wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(15));

        bool AdIsPresent(IWebDriver webDriver)
        {
            var ad = webDriver.FindElement(By.XPath("//ins[@data-anchor-status=\"displayed\"]"));
            return ad.Displayed;
        }

        if (AdIsPresent(webdriver))
        {
            executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                   "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        }

        wait.Until(AdIsPresent);
    }
}