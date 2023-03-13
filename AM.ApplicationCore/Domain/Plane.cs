using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing, Airbus}
    public class Plane
    {
        [Range(0, int.MaxValue)] 
        public int capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Plane Id: " + this.PlaneId;
        }
        //public Plane() { }
        //public Plane(PlaneType pt, int capacity, DateTime date)
        //{
        //    this.capacity = capacity;
        //    this.ManufactureDate = date;
        //    this.PlaneType = pt;
        //}
    }
}
