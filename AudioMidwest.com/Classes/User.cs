using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioMidwest.com
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string RecoveryEmail { get; set; }
    }
}