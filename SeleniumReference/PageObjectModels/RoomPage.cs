using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class RoomPage : BasePage
    {
        internal readonly By pageSentinel = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[1]/div[1]/h1");
        internal readonly By todayButton = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[2]/div/div/form/div[1]/div/div[1]/span[1]/button[1]");
        internal readonly By reserveNow1Button = By.Id(@"doReservation");
        internal readonly By firstNameTextbox = By.Name(@"firstname");
        internal readonly By lastNameTextbox = By.Name(@"lastname");
        internal readonly By emailTextbox = By.Name(@"email");
        internal readonly By phoneTextbox = By.Name(@"phone");
        internal readonly By reserveNow2Button = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[2]/div/div/form/button[1]");
        internal readonly By bookingConfirmed = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[2]/div/div/h2");
        internal readonly By suiteBookingConfirmation = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[2]/div/div/h2");
        internal readonly By cancelButton = By.XPath(@"/html/body/div[2]/div/div[2]/div/div[2]/div/div/form/button[2]");
        internal readonly By returnHomeButton = By.LinkText(@"Return home");

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

        internal bool IsRoomSite(string roomType) => roomType switch
        {
            "Single" => GetVisibleWebElement(pageSentinel).Text == "Single Room",
            "Double" => GetVisibleWebElement(pageSentinel).Text == "Double Room",
            "Suite"  => GetVisibleWebElement(pageSentinel).Text == "Suite Room",
            _ => throw new Exception("Room not found.")
        };

        /// <summary>
        /// Displays the 'Book This Room' form, fills it with customer information, and submits it.
        /// Keys do not have to be named, because customer information is accessed by index.
        /// </summary>
        /// <param name="customerInformation">String List of First Name, Last Name, Email, and Phone.</param>
        internal void ReserveRoom(List<string> customerInformation)
        {
            GetVisibleWebElement(todayButton).Click();
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
