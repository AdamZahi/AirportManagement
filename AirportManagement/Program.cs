// See https://aka.ms/new-console-template for more information
using AM.APP.CORE.domain;
using AM.APP.CORE.Service;

FlightMethod fm = new FlightMethod();
fm.Flights = TestData.listFlights;
//foreach (var item in fm.GetFlightDates("Paris"))
//    {
//        Console.WriteLine(item);
//    }
//Console.WriteLine("----- Flights to Paris -----");
//fm.GetFlights("Destination", "Paris");

//Console.WriteLine("----- Flights from Tunis -----");
//fm.GetFlights("Departure", "Tunis");

fm.ShowFlightDetails(TestData.BoingPlane);