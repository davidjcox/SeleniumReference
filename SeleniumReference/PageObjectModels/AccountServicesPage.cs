using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumReference.UtilityModels;

namespace SeleniumReference.PageObjectModels
{
    internal class AccountServicesPage : BasePage
    {
        internal readonly By pageSentinel = By.TagName(@"h2");
        internal readonly By openNewAccountLink = By.LinkText(@"Open New Account");
        internal readonly By newAccountIdLink = By.Id(@"newAccountId");
        internal readonly By accountsOverviewLink = By.LinkText(@"Accounts Overview");
        internal readonly By transferFundsLink = By.LinkText(@"Transfer Funds");
        internal readonly By billPayLink = By.LinkText(@"Bill Pay");
        internal readonly By findTransactionsLink = By.LinkText(@"Find Transactions");
        internal readonly By updateContactInfoLink = By.LinkText(@"Update Contact Info");
        internal readonly By requestLoanLink = By.LinkText(@"Request Loan");
        internal readonly By logOutLink = By.LinkText(@"Log Out");
        internal readonly By accountTypeDropdown = By.Id(@"type");
        internal readonly By openNewAccountButton = By.CssSelector(@"[value='Open New Account']");
        internal readonly By amountTextbox = By.Id(@"amount");
        internal readonly By transferButton = By.CssSelector(@"[value='Transfer']");

        public AccountServicesPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        internal bool IsExpectedSite()
        {
            return GetVisibleWebElement(pageSentinel).Text == "Account Services";
        }

        internal void OpenNewAccount(string accountType)
        {
            IWebElement selectElement = GetVisibleWebElement(accountTypeDropdown);
            SelectElement accountTypeSelector = new SelectElement(selectElement);

            accountTypeSelector.SelectByText(accountType);
            GetVisibleWebElement(openNewAccountButton).Click();
        }

        /// <summary>
        /// Displays the 'Open New Account' form, selects account type, fills it with customer information, and submits it.
        /// </summary>
        /// <param name="customerInformation">CustomerInformation object</param>
        internal void ReserveRoom(CustomerInformation customerInformation)
        {
            GetVisibleWebElement(openNewAccountLink).Click();
            GetVisibleWebElement(accountsOverviewLink).Click();
            SendKeysToElement(GetVisibleWebElement(transferFundsLink), customerInformation.FirstName);
            SendKeysToElement(GetVisibleWebElement(billPayLink), customerInformation.LastName);
            SendKeysToElement(GetVisibleWebElement(findTransactionsLink), customerInformation.Email);
            SendKeysToElement(GetVisibleWebElement(updateContactInfoLink), customerInformation.PhoneNumber);
            GetVisibleWebElement(requestLoanLink).Click();
        }
    }
}
