using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class BookingPage : BasePage
    {
        internal readonly Uri pageUrl = new Uri(@"https://automationintesting.online/");
        internal readonly By pageSentinel = By.ClassName(@"mb-3");
        internal readonly By bookNowButton = By.LinkText(@"Book now");
        internal readonly By messageNameTextbox = By.Id(@"name");
        internal readonly By messageEmailTextbox = By.Id(@"email");
        internal readonly By messagePhoneTextbox = By.Id(@"phone");
        internal readonly By messageSubjectTextbox = By.Id(@"subject");
        internal readonly By messageDescriptionTextBox = By.Id(@"description");
        internal readonly By messageSubmitButton = By.TagName(@"button");

        public BookingPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        enum Rooms
        {
            Single,
            Double,
            Suite
        }

        enum Parts
        {
            Name,
            Email,
            Phone,
            Subject,
            Message
        }

        internal bool IsBookingSite()
        {
            return IsExpectedUrl(pageUrl) && IsExpectedPage(pageSentinel);
        }

        internal void ChooseSingleRoom()
        {
            GetVisibleWebElements(bookNowButton)[(int)Rooms.Single].Click();
        }

        internal void ChooseDoubleRoom()
        {
            GetVisibleWebElements(bookNowButton)[(int)Rooms.Double].Click();
        }

        internal void ChooseSuiteRoom()
        {
            GetVisibleWebElements(bookNowButton)[(int)Rooms.Suite].Click();
        }

        /// <summary>
        /// Fills the 'Send Us a Message' form with message parts and submits it.
        /// Keys do not have to be named, because message parts are accessed by index.
        /// </summary>
        /// <param name="messageParts">String List of Name, Email, Phone, Subject, and Message.</param>
        internal void SendAMessage(List<string> messageParts)
        {
            SendKeysToElement(GetVisibleWebElement(messageNameTextbox), messageParts[(int)Parts.Name]);
            SendKeysToElement(GetVisibleWebElement(messageEmailTextbox), messageParts[(int)Parts.Email]);
            SendKeysToElement(GetVisibleWebElement(messagePhoneTextbox), messageParts[(int)Parts.Phone]);
            SendKeysToElement(GetVisibleWebElement(messageSubjectTextbox), messageParts[(int)Parts.Subject]);
            SendKeysToElement(GetVisibleWebElement(messageDescriptionTextBox), messageParts[(int)Parts.Message]);
            GetVisibleWebElement(messageSubmitButton).Click();
        }

    }
}