using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KansasCity311
{
    public class ContactInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IncludeContactInfo { get; set; }


        public ContactInformation(string firstName, string lastName, string emailAddress, string phoneNumber, bool includeContactInformation)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            IncludeContactInfo = includeContactInformation;
        }
    }
}
