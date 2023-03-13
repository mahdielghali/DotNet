using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight:IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.Destination; //f.Destination est le g.Key
            //foreach (var g in query) {
            //    Console.WriteLine("Destination " + g.Key);
            //    foreach(var v in g)
            //    {
            //        Console.WriteLine("decolage : " + v.FlightDate);
            //    }
            //}
            //return query;
            IEnumerable<IGrouping<string, Flight>> queryLambda = Flights
                .GroupBy(f => f.Destination);
            foreach (var g in queryLambda)
            {
                Console.WriteLine("Destination " + g.Key);
                foreach (var v in g)
                {
                    Console.WriteLine("decolage : " + v.FlightDate);
                }
            }
            return queryLambda;
        }

        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;
            //return query.Average();
            IEnumerable<int> queryLambda = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return queryLambda.Average();
        }

        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    for(int i=0; i< Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination.Equals(destination))
        //        {
        //            result.Add(Flights[i].FlightDate);
        //        }
        //    }
        //    return result;
        //}
        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    foreach (var flight in Flights)
        //    {
        //        if (flight.Destination== destination)
        //        {
        //            result.Add(flight.FlightDate);
        //        }
        //    }
        //    return result;
        //}

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //IEnumerable<DateTime> query = from f in Flights 
            //                              where f.Destination == destination 
            //                              select f.FlightDate;
            //return query;
            //question 19
            IEnumerable<DateTime> queryLambda = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return queryLambda;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach( Flight flight in Flights)
                    {
                        if(flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f;
            //return query;
            IEnumerable<Flight> queryLambda = Flights
                .OrderByDescending(f =>f.EstimatedDuration)
                .Select(f => f);
            return queryLambda;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from f in Flights
            //            where (DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7)
            //            select f;
            //return query.Count();
            IEnumerable<Flight> queryLambda = Flights
                .Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7)
                .Select(f => f);
            return queryLambda.Count();

        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.Passengers.OfType<Traveller>()
            //            orderby p.BirthDate ascending
            //            select p;
            //return query.Take(3);


            //IEnumerable<Passenger> queryLambda = flight.Passengers.OfType<Traveller>()
            //   .OrderBy(p => p.BirthDate)
            //   .Select(p => p);
            //return queryLambda.Take(3);


            return null;
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane == plane
            //            select f;
            //foreach (var f in query)
            //{
            //    Console.WriteLine("destination: " + f.Destination + "flightDate : " + f.FlightDate);
            //}
            IEnumerable<Flight> queryLambda = Flights
               .Where(f => f.Plane == plane)
               .Select(f => f);
            foreach (var f in queryLambda)
            {
                Console.WriteLine("destination: " + f.Destination + "flightDate : " + f.FlightDate);
            }
        }


        public Action<Domain.Plane> FlightDetailsDel;

        public Func<string, double> DurationAverageDel;


        ////ctor double tabulation to get this
        //public ServiceFlight()
        //{

        //}

        public ServiceFlight()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = plane => {
                var query = from f in Flights
                            where f.Plane == plane
                            select f;
                foreach (var f in query)
                {
                    Console.WriteLine("destination: " + f.Destination + "flightDate : " + f.FlightDate);
                }
            };
            DurationAverageDel = destination => {
                var query = from f in Flights
                            where f.Destination == destination
                            select f.EstimatedDuration;
                return query.Average();
            };
        }

    }
}
