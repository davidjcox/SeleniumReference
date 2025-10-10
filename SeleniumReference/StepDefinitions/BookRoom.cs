using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumReference.PageObjectModels;

namespace SeleniumReference.StepDefinitions
{
    [Binding]
    internal class BookRoom : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private HomePage _bookingPage;
        private AccountServicesPage _roomPage;

        public BookRoom()
        {
            _driver = new EdgeDriver();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            _bookingPage = new HomePage(_driver, _wait);
            _roomPage = new AccountServicesPage(_driver, _wait);
        }

        [Given("I have navigated to the booking site")]
        public void GivenIHaveNavigatedToTheBookingSite()
        {
            _bookingPage.NavigateTo(_bookingPage.pageUrl);

            Assert.That(_bookingPage.IsExpectedSite());
        }

        [When("I select the option to book a Single room")]
        public void WhenISelectTheOptionToBookASingleRoom()
        {
            _bookingPage.ChooseSingleRoom();
        }

        [When("I complete the room reservation form")]
        public void WhenICompleteTheRoomReservationForm()
        {
            List<string> customerInformation = new List<string>()
            {
                "Jack",
                "Tripper",
                "jtripper@email.com",
                "16125551212"
            };

            _roomPage.ReserveRoom(customerInformation);
        }

        [Then("the room booking confirmation displays")]
        public void ThenTheRoomBookingConfirmationDisplays()
        {
            throw new PendingStepException();
        }

        [When("I select the option to book a Double room")]
        public void WhenISelectTheOptionToBookADoubleRoom()
        {
            _bookingPage.ChooseDoubleRoom();
        }

        [When("I select the option to book a Suite room")]
        public void WhenISelectTheOptionToBookASuiteRoom()
        {
            _bookingPage.ChooseSuiteRoom();
        }

        [When("I cancel before booking the room")]
        public void WhenICancelBeforeBookingTheRoom()
        {
            _roomPage.DoNotReserveRoom();
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

            _bookingPage.SendAMessage(messageParts);
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
