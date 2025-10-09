using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class RoomPage : BasePage
    {
        internal readonly By reserveNow1Button = By.Id(@"doReservation");
        internal readonly By firstNameTextbox = By.Name(@"firstname");
        internal readonly By lastNameTextbox = By.Name(@"lastname");
        internal readonly By emailTextbox = By.Name(@"email");
        internal readonly By phoneTextbox = By.Name(@"phone");
        internal readonly By reserveNow2Button = By.ClassName(@"btn btn-primary w-100 mb-3");
        internal readonly By bookingConfirmed = By.ClassName(@"card-title fs-4 fw-bold mb-3");
        internal readonly By cancelButton = By.ClassName(@"btn btn-secondary w-100 mb-3");

        public RoomPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        enum Info
        {
            FirstName,
            LastName,
            Email,
            Phone
        }

        /// <summary>
        /// Displays the 'Book This Room' form, fills it with customer information, and submits it.
        /// Keys do not have to be named, because customer information is accessed by index.
        /// </summary>
        /// <param name="customerInformation">String List of First Name, Last Name, Email, and Phone.</param>
        internal void ReserveRoom(List<string> customerInformation)
        {
            GetVisibleWebElement(reserveNow1Button).Click();
            SendKeysToElement(GetVisibleWebElement(firstNameTextbox), customerInformation[(int)Info.FirstName]);
            SendKeysToElement(GetVisibleWebElement(lastNameTextbox), customerInformation[(int)Info.LastName]);
            SendKeysToElement(GetVisibleWebElement(emailTextbox), customerInformation[(int)Info.Email]);
            SendKeysToElement(GetVisibleWebElement(phoneTextbox), customerInformation[(int)Info.Phone]);
            GetVisibleWebElement(reserveNow2Button).Click();
        }

        /// <summary>
        /// Displays the 'Book This Room' form but cancels without filling it out.
        /// </summary>
        internal void DoNotReserveRoom()
        {
            GetVisibleWebElement(reserveNow1Button).Click();
            GetVisibleWebElement(cancelButton).Click();
        }
    }
}
