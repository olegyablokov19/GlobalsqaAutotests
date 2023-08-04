using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDD;

public class Waiters
{
    public static void WaitForAdToClose(IWebDriver webdriver, IJavaScriptExecutor executor)
    {
        var wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(15));

        bool AdIsPresent(IWebDriver webdriver)
        {
            try
            {
                var adLocator = By.XPath("//ins[@data-anchor-status=\"displayed\"]");
                var ad = webdriver.FindElement(adLocator);
                if (ad.Displayed && ad.Enabled)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        if (AdIsPresent(webdriver))
        {
            executor.ExecuteScript("const a = document.getElementsByClassName(\"adsbygoogle adsbygoogle-noablate\");" +
                                   "for (let i =0; i < a.length; i++) { a[i].style.height = \"0px\"; }");
        }
        else
        {
            Console.WriteLine("No ad at the moment");
        }

        wait.Until(AdIsPresent);
    }
}