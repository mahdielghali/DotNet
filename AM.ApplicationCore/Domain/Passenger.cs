using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name ="name of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
       
        public FullName Fullname { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public string? TelNumber { get; set; }
        public int Id { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public override string ToString()
        {
            return "FirstName & LastName: " + this.Fullname.FirstName + this.Fullname.LastName;
        }
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return firstName == this.FirstName && lastName == this.LastName;
        //}
        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return firstName == this.FirstName && lastName == this.LastName && email==this.EmailAddress;
        //}
        public bool CheckProfile(string firstName, string lastName, string email=null)
        {
            if (email== null)
            {
                return firstName == this.Fullname.FirstName && lastName == this.Fullname.LastName;
            }
            return firstName == this.Fullname.FirstName && lastName == this.Fullname.LastName && email == this.EmailAddress;
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
