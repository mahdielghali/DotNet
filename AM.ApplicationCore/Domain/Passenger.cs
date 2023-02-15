using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> flights { get; set; }
        public override string ToString()
        {
            return "First Name= " + FirstName + "Last Name= " + LastName;
        }
        //public bool CheckProfile(string firstname, string lastname)
        //{
        //    return FirstName == firstname && LastName == lastname;
        //}
        //public bool CheckProfile(string firstname, string lastname, string emailadresse)
        //{
        //    return FirstName == firstname && LastName == lastname && EmailAdress == emailadresse;
        //}
        public bool CheckProfile(string firstname, string lastname, string emailadresse = null)
        {
            if (emailadresse != null)
                return FirstName == firstname && LastName == lastname && EmailAdress == emailadresse;
            else
                return FirstName == firstname && LastName == lastname;
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");

        }
    }
}
