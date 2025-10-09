Feature: BookRoom

Reserve a room for the current date on the Shady Meadows B&B site ('https://automationintesting.online/')

@tag1
Scenario: Reserve a Single room
	Given I have navigated to the booking site
	When I select the option to book a Single room
	And I complete the room reservation form
	Then the room booking confirmation displays

@tag1
Scenario: Reserve a Double room
	Given I have navigated to the booking site
	When I select the option to book a Double room
	And I complete the room reservation form
	Then the room booking confirmation displays

@tag1
Scenario: Reserve a Suite room
	Given I have navigated to the booking site
	When I select the option to book a Suite room
	And I complete the room reservation form
	Then the room booking confirmation displays

Scenario: Decline to reserve a room
	Given I have navigated to the booking site
	When I select the option to book a Single room
	And I cancel before booking the room
	Then the option to book the room displays again

@tag1
Scenario: Send them a message
	Given I have navigated to the booking site
	When I fill out and submit the send a message form
	Then a message confirmation is displayed