using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumReference.UtilityModels;

namespace SeleniumReference.PageObjectModels
{
    internal class HomePage : BasePage
    {
        internal readonly Uri pageUrl = new Uri(@"https://parabank.parasoft.com/parabank/index.htm");
        internal readonly By pageSentinel = By.ClassName(@"logo");
        internal readonly By registerLink = By.LinkText(@"Register");
        internal readonly By firstNameTextbox = By.Id(@"customer.firstName");
        internal readonly By lastNameTextbox = By.Id(@"customer.lastName");
        internal readonly By addressTextbox = By.Id(@"customer.address.street");
        internal readonly By cityTextbox = By.Id(@"customer.address.city");
        internal readonly By stateTextBox = By.Id(@"customer.address.state");
        internal readonly By zipCodeTextbox = By.Id(@"customer.address.zipCode");
        internal readonly By phoneNumberTextbox = By.Id(@"customer.phoneNumber");
        internal readonly By ssnTextbox = By.Id(@"customer.ssn");
        internal readonly By usernameTextbox = By.Id(@"customer.username");
        internal readonly By passwordTextbox = By.Id(@"customer.password");
        internal readonly By confirmTextbox = By.Id(@"repeatedPassword");
        internal readonly By registerButton = By.CssSelector(@"[value='Register']");

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        internal bool IsExpectedSite()
        {
            return IsExpectedUrl(pageUrl) && IsExpectedPage(pageSentinel);
        }

        /// <summary>
        /// Fills in the new account registration form with customer information and submits it.
        /// Customer information list items must be added according to CustInfo order because form is filled by iterating list index.
        /// </summary>
        /// <param name="customerInformation">String List of First Name, Last Name, (street) Address, City, State, Zip Code, Phone Number, SSN, Username, Password, and (confirmed) Password.</param>
        internal void RegisterNewAccount(CustomerInformation customerInformation)
        {
            GetVisibleWebElement(registerLink).Click();
            SendKeysToElement(GetVisibleWebElement(firstNameTextbox), customerInformation.FirstName);
            SendKeysToElement(GetVisibleWebElement(lastNameTextbox), customerInformation.LastName);
            SendKeysToElement(GetVisibleWebElement(addressTextbox), customerInformation.StreetAddress);
            SendKeysToElement(GetVisibleWebElement(cityTextbox), customerInformation.City);
            SendKeysToElement(GetVisibleWebElement(stateTextBox), customerInformation.State);
            SendKeysToElement(GetVisibleWebElement(zipCodeTextbox), customerInformation.ZipCode);
            SendKeysToElement(GetVisibleWebElement(phoneNumberTextbox), customerInformation.PhoneNumber);
            SendKeysToElement(GetVisibleWebElement(ssnTextbox), customerInformation.Ssn);
            SendKeysToElement(GetVisibleWebElement(usernameTextbox), customerInformation.Username);
            SendKeysToElement(GetVisibleWebElement(passwordTextbox), customerInformation.Password1);
            SendKeysToElement(GetVisibleWebElement(confirmTextbox), customerInformation.Password2);
            GetVisibleWebElement(registerButton).Click();
        }
    }
}