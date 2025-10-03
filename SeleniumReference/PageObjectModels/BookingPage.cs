using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumReference.PageObjectModels
{
    internal class BookingPage : BasePage
    {
        private readonly By pageSentinel = By.ClassName(@"mb-3");
        private readonly By bookNowButton = By.LinkText(@"Book now");
        private readonly By messageNameTextbox = By.Id(@"name");
        private readonly By messageEmailTextbox = By.Id(@"email");
        private readonly By messagePhoneTextbox = By.Id(@"phone");
        private readonly By messageSubjectTextbox = By.Id(@"subject");
        private readonly By messageDescriptionTextBox = By.Id(@"description");
        private readonly By messageSubmitButton = By.TagName(@"button");

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