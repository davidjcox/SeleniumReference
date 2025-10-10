
namespace SeleniumReference.UtilityModels
{
    internal class CustomerInformation
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Ssn { get; private set; }
        public string Username { get; private set; }
        public string Password1 { get; private set; }
        public string Password2 { get; private set; }

        public CustomerInformation()
        {
            FirstName = "Kage";
            LastName = "Baker";
            Email = "kage.baker@pismobeachscifiauthors.com";
            StreetAddress = "760 Mattie Road";
            City = "Pismo Beach";
            State = "California";
            ZipCode = "93449";
            PhoneNumber = "805.773.4657";
            Ssn = "321-654-0987";
            Username = "kage.baker";
            Password1 = "drowssap";
            Password2 = "drowssap";
        }

        public CustomerInformation(
            string firstName,
            string lastName,
            string email,
            string streetAddress,
            string city,
            string state,
            string zipCode,
            string phoneNumber,
            string ssn,
            string username,
            string password1,
            string password2
            )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            Ssn = ssn;
            Username = username;
            Password1 = password1;
            Password2 = password2;
        }
    }
}
