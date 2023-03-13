// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
//Console.WriteLine("Hello, World!");
////Plane Plane1  = new Plane();
////Plane1.capacity= 200;
////Plane1.ManufactureDate = new DateTime(2013, 01, 31);
////Plane1.PlaneType = PlaneType.Boing;

////Plane Plane2 = new Plane(PlaneType.Boing, 100, new DateTime(2013, 01, 31));


//Plane Plane3 = new Plane()
//{
//    capacity= 3,
//    ManufactureDate= DateTime.Now,
//    PlaneType = PlaneType.Airbus
//};


Passenger passenger1 = new Passenger
{
    Fullname = new FullName
    {
        FirstName = "mahdi",
        LastName = "ghalis",
    },
        EmailAddress = "mahdi.ghalis@esprit.tn"
};
//Console.WriteLine(passenger1.CheckProfile("mahdi", "ghalis", "mahdi.ghalis@esprit.tn"));
//Traveller Traveller1 = new Traveller
//{
//    FirstName = "mahdi",
//    LastName = "ghalis",
//    Nationality = "Tunisienne"
//};
//Console.WriteLine("Traveller1: ");
//Traveller1.PassengerType();
//Staff Staff1 = new Staff
//{
//    FirstName = "mahdi",
//    LastName = "ghalis",
//    Salary = 1000.0
//};
//Console.WriteLine("Staff1 : ");
//Staff1.PassengerType();
ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights;
foreach(var item in sf.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
};
sf.GetFlights("Destination", "Paris");
//sf.ShowFlightDetails(TestData.BoingPlane); 
sf.FlightDetailsDel(TestData.BoingPlane); //(question 17 et 18)
Console.WriteLine("total flights: " + sf.ProgrammedFlightNumber(new DateTime(2022,02,01)));
Console.WriteLine("total Average : " + sf.DurationAverage("Paris"));
foreach(var item in sf.OrderedDurationFlights())
{
    Console.WriteLine(item);
}
foreach(var item in sf.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
sf.DestinationGroupedFlights();
Console.WriteLine(passenger1.Fullname.FirstName + passenger1.Fullname.LastName);
passenger1.UpperFullName();
Console.WriteLine(passenger1.Fullname.FirstName + passenger1.Fullname.LastName);
AMContext ctx = new AMContext();
ctx.Flights.Add(TestData.flight1);
ctx.SaveChanges();
