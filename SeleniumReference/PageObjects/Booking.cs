using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjects
{
    public class Booking : BasePage
    {
        public IWebElement sentinel;

        public Booking(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            sentinel = GetVisibleWebElement(By.ClassName(@"navbar-brand d-flex align-items-center"), GetVisibleWebElement(By.TagName(@"span")));
        }

        
    }
}