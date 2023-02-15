using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < flights.Count; i++)
            //{
            //    if (flights[i].Destination == destination)
            //    {
            //        result.Add(flights[i].FlightDate);
            //    }
            //}
            //return result;
            //foreach(var flight in flights)
            //{
            //    if(flight.Destination== destination)
            //    {
            //        result.Add(flight.FlightDate);
            //    }
            //}
            //return result;
            //IEnumerable<DateTime> query= from f in flights 
            //                             where f.Destination== destination 
            //                             select f.FlightDate;
            //return query;
            IEnumerable<DateTime> queryLambda = flights
                .Where(f=>f.Destination == destination)
                .Select(f=>f.FlightDate);
            return queryLambda;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    foreach(Flight flight in flights)
                    {
                        if(flight.Destination.Equals(filterValue)) 
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight flight in flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in flights
            //            where f.MyPlane == plane
            //            select f;
            //foreach(var f in query)
            //{
            //    Console.WriteLine("destination : " + f.Destination + "flight Date :" + f.FlightDate);
            //}
            var queryLambda = flights
                .Where(f => f.MyPlane == plane)
                .Select(p => p);
            foreach (var v in queryLambda)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {

            //var query = from f in flights
            //            where (DateTime.Compare(f.FlightDate, startDate) > 0
            //            && (f.FlightDate - startDate).TotalDays < 7)
            //            select f;

            //return query.Count();
            var reqLambda = flights
                .Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7);
            return reqLambda.Count();
        }

        public double DurationAverage(string destination)
        {
            //var query = from f in flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;

            //return query.Average();
            var reqLambda = flights
                .Where(f => f.Destination.Equals(destination))
                .Select(f => f.EstimatedDuration);
            return reqLambda.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in flights
            //            orderby f.EstimatedDuration descending
            //            select f;

            //return query;
            var reqLambda = flights.OrderByDescending(f => f.EstimatedDuration);
            return reqLambda;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.Passengers.OfType<Traveller>()
            //            orderby p.BirthDate ascending //par defaut
            //            select p;

            //return query.Take(3);
            var reqLambda = flight.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);
            return reqLambda;
        }

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights()
        {
            //var query = from f in flights
            //            group f by f.Destination;
            var reqLambda = flights.GroupBy(f => f.Destination);
            foreach (var group in reqLambda)
            {
                Console.WriteLine("Destination " + group.Key);
                foreach(var v in group)
                {
                    Console.WriteLine("Decollage: " + v.FlightDate);
                }
            }
            return reqLambda;
        }

        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailsDel = plane =>
            {
                var query = from f in flights
                            where f.MyPlane == plane
                            select f;
                foreach (var f in query)
                {
                    Console.WriteLine("destination : " + f.Destination + "flight Date :" + f.FlightDate);
                }
            };
            DurationAverageDel = destination =>
            {
                var query = from f in flights
                            where f.Destination == destination
                            select f.EstimatedDuration;

                return query.Average();
            };
        }
    }
}
