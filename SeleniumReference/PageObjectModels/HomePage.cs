using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        enum CustInfo
        {
            FirstName,
            LastName,
            Address,
            City,
            State,
            ZipCode,
            PhoneNumber,
            SSN,
            UserName,
            Password1,
            Password2
        }

        internal bool IsExpectedSite()
        {
            return IsExpectedUrl(pageUrl) && IsExpectedPage(pageSentinel);
        }

        /// <summary>
        /// Fills the 'Send Us a Message' form with message parts and submits it.
        /// Keys do not have to be named, because message parts are accessed by index.
        /// </summary>
        /// <param name="customerInformation">String List of First Name, Last Name, Address, City, State, Zip Code, Phone Number, SSN, Username, Password, and Confirmed Password.</param>
        internal void SendAMessage(List<string> customerInformation)
        {
            GetVisibleWebElement(registerLink).Click();
            SendKeysToElement(GetVisibleWebElement(firstNameTextbox), customerInformation[(int)CustInfo.FirstName]);
            SendKeysToElement(GetVisibleWebElement(lastNameTextbox), customerInformation[(int)CustInfo.LastName]);
            SendKeysToElement(GetVisibleWebElement(addressTextbox), customerInformation[(int)CustInfo.Address]);
            SendKeysToElement(GetVisibleWebElement(cityTextbox), customerInformation[(int)CustInfo.City]);
            SendKeysToElement(GetVisibleWebElement(stateTextBox), customerInformation[(int)CustInfo.State]);
            SendKeysToElement(GetVisibleWebElement(zipCodeTextbox), customerInformation[(int)CustInfo.ZipCode]);
            SendKeysToElement(GetVisibleWebElement(phoneNumberTextbox), customerInformation[(int)CustInfo.PhoneNumber]);
            SendKeysToElement(GetVisibleWebElement(ssnTextbox), customerInformation[(int)CustInfo.SSN]);
            SendKeysToElement(GetVisibleWebElement(usernameTextbox), customerInformation[(int)CustInfo.UserName]);
            SendKeysToElement(GetVisibleWebElement(passwordTextbox), customerInformation[(int)CustInfo.Password1]);
            SendKeysToElement(GetVisibleWebElement(confirmTextbox), customerInformation[(int)CustInfo.Password2]);
            GetVisibleWebElement(registerButton).Click();
        }
    }
}