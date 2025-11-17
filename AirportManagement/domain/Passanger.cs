using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.domain
{
    public class Passanger
    {
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }

        public bool checkProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }
        public bool checkProfile(string firstName, string lastName, string emailAdress)
        {
            return EmailAddress.Equals(emailAdress) && FirstName == firstName && LastName == lastName;
        }
        public bool logIn(string firstName, string lastName, string emailAdress = null)
        {
            if (emailAdress == null)
            {
                return FirstName == firstName && LastName == lastName;
            }
            return EmailAddress.Equals(emailAdress) && FirstName == firstName && LastName == lastName;
        }
        public virtual void passangerType()
        {
            Console.WriteLine("I'm a passanger!");
        }
    }
}
