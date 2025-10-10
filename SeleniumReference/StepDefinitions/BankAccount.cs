using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumReference.PageObjectModels;

namespace SeleniumReference.StepDefinitions
{
    [Binding]
    internal class BankAccount : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private HomePage _homePage;
        private AccountServicesPage _accountServicesPage;

        public BankAccount()
        {
            _driver = new EdgeDriver();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            _homePage = new HomePage(_driver, _wait);
            _accountServicesPage = new AccountServicesPage(_driver, _wait);
        }

        struct CustomerInformation
        {
            internal string FirstName;
            internal string LastName;
            internal string Email;
            internal string PhoneNumber;
        }

        [Given("I have navigated to the booking site")]
        public void GivenIHaveNavigatedToTheBookingSite()
        {
            _homePage.NavigateTo(_homePage.pageUrl);

            Assert.That(_homePage.IsExpectedSite());
        }

        [When("I select the option to book a Single room")]
        public void WhenISelectTheOptionToBookASingleRoom()
        {
            _homePage.ChooseSingleRoom();
        }

        [When("I complete the room reservation form")]
        public void WhenICompleteTheRoomReservationForm()
        {
            CustomerInformation customerInformation = new CustomerInformation();

            _accountServicesPage.ReserveRoom(customerInformation);
        }

        [Then("the room booking confirmation displays")]
        public void ThenTheRoomBookingConfirmationDisplays()
        {
            throw new PendingStepException();
        }

        [When("I select the option to book a Double room")]
        public void WhenISelectTheOptionToBookADoubleRoom()
        {
            _homePage.ChooseDoubleRoom();
        }

        [When("I select the option to book a Suite room")]
        public void WhenISelectTheOptionToBookASuiteRoom()
        {
            _homePage.ChooseSuiteRoom();
        }

        [When("I cancel before booking the room")]
        public void WhenICancelBeforeBookingTheRoom()
        {
            _accountServicesPage.DoNotReserveRoom();
        }

        [Then("the option to book the room displays again")]
        public void ThenTheOptionToBookTheRoomDisplaysAgain()
        {
            throw new PendingStepException();
        }

        [When("I fill out and submit the send a message form")]
        public void WhenIFillOutAndSubmitTheSendAMessageForm()
        {
            List<string> messageParts = new List<string>()
            {
                "Jack Tripper",
                "jtripper@email.com",
                "16125551212",
                "Directions to B&B",
                "I seem to have gotten lost on the way to the B&B. Could you give me directions?"
            };

            _homePage.RegisterNewAccount(messageParts);
        }

        [Then("a message confirmation is displayed")]
        public void ThenAMessageConfirmationIsDisplayed()
        {
            throw new PendingStepException();
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
