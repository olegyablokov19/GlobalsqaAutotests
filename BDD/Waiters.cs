using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD;

public class Waiters
{
    public static void WaitForAdToClose(IWebDriver webdriver, IJavaScriptExecutor executor)
    {
        var wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(3));

        var adLocator = By.XPath("//ins[@data-anchor-status=\"displayed\"]");
        IWebElement ad = wait.Until(x => x.FindElement(adLocator));
        if (ad != null)
        {
            executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                   "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        }
    }
}
