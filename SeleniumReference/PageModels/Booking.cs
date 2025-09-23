using OpenQA.Selenium;

namespace SeleniumReference.PageModels
{
    public class Booking
    {
        private IWebDriver _driver;

        public Booking(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement sentinel = _driver.FindElement(By.Id(@"container")
    }
}
