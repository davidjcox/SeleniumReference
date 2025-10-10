using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class AccountServicesPage : BasePage
    {
        internal readonly By pageSentinel = By.TagName(@"h2");
        internal readonly By openNewAccountLink = By.LinkText(@"Open New Account");
        internal readonly By accountsOverviewLink = By.LinkText(@"Accounts Overview");
        internal readonly By transferFundsLink = By.LinkText(@"Transfer Funds");
        internal readonly By billPayLink = By.LinkText(@"Bill Pay");
        internal readonly By findTransactionsLink = By.LinkText(@"Find Transactions");
        internal readonly By updateContactInfoLink = By.LinkText(@"Update Contact Info");
        internal readonly By requestLoanLink = By.LinkText(@"Request Loan");
        internal readonly By logOutLink = By.LinkText(@"Log Out");
        internal readonly By openNewAccountButton = By.CssSelector(@"[value='Open New Account']");
        internal readonly By amountTextbox = By.Id(@"amount");
        internal readonly By transferButton = By.CssSelector(@"[value='Transfer']");

        public AccountServicesPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        enum Info
        {
            FirstName,
            LastName,
            Email,
            Phone
        }

        internal bool IsExpectedSite()
        {
            return GetVisibleWebElement(pageSentinel).Text == "Account Services";
        }

        /// <summary>
        /// Displays the 'Book This Room' form, fills it with customer information, and submits it.
        /// Keys do not have to be named, because customer information is accessed by index.
        /// </summary>
        /// <param name="customerInformation">String List of First Name, Last Name, Email, and Phone.</param>
        internal void ReserveRoom(List<string> customerInformation)
        {
            GetVisibleWebElement(openNewAccountLink).Click();
            GetVisibleWebElement(accountsOverviewLink).Click();
            SendKeysToElement(GetVisibleWebElement(transferFundsLink), customerInformation[(int)Info.FirstName]);
            SendKeysToElement(GetVisibleWebElement(billPayLink), customerInformation[(int)Info.LastName]);
            SendKeysToElement(GetVisibleWebElement(findTransactionsLink), customerInformation[(int)Info.Email]);
            SendKeysToElement(GetVisibleWebElement(updateContactInfoLink), customerInformation[(int)Info.Phone]);
            GetVisibleWebElement(requestLoanLink).Click();
        }
    }
}
