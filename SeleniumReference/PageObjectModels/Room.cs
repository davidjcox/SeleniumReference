using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class Room : BasePage
    {
        private readonly By reserveNow1Button = By.Id(@"doReservation");
        private readonly By firstNameTextbox = By.Name(@"firstname");
        private readonly By lastNameTextbox = By.Name(@"lastname");
        private readonly By emailTextbox = By.Name(@"email");
        private readonly By phoneTextbox = By.Name(@"phone");
        private readonly By reserveNow2Button = By.ClassName(@"btn btn-primary w-100 mb-3");
        private readonly By cancelButton = By.ClassName(@"btn btn-secondary w-100 mb-3");

        public Room(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        enum Info
        {
            FirstName,
            LastName,
            Email,
            Phone
        }

        internal void ReserveRoom(List<string> customerInformation)
        {
            GetVisibleWebElement(reserveNow1Button).Click();
            SendKeysToElement(GetVisibleWebElement(firstNameTextbox), customerInformation[(int)Info.FirstName]);
            SendKeysToElement(GetVisibleWebElement(lastNameTextbox), customerInformation[(int)Info.LastName]);
            SendKeysToElement(GetVisibleWebElement(emailTextbox), customerInformation[(int)Info.Email]);
            SendKeysToElement(GetVisibleWebElement(phoneTextbox), customerInformation[(int)Info.Phone]);
            GetVisibleWebElement(reserveNow2Button).Click();
        }

        internal void DoNotReserveRoom()
        {
            GetVisibleWebElement(reserveNow1Button).Click();
            GetVisibleWebElement(cancelButton).Click();
        }
    }
}
