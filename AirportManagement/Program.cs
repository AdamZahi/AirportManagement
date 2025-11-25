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

//fm.ShowFlightDetails(TestData.BoingPlane);
int nb_flight = fm.ProgrammedFlightNumber(DateTime.Now);
Console.WriteLine($"Nombre de flights programmés à partir de la date courante: {nb_flight}");
var avg_duration = fm.DurationAverage("Madrid");
Console.WriteLine($"Durée moyenne des flights à destination de Madrid: {avg_duration}");
var seniorTravellers = fm.SeniorTravellers(TestData.flight1);
Console.WriteLine("Les 3 Travellers les plus âgés du flight1:");
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"{traveller.FirstName} {traveller.LastName}, Né le: {traveller.BirthDate:dd/MM/yyyy}");
}
var orderFlight = fm.OrderedDurationFlights();
Console.WriteLine("Flights ordonnés par durée décroissante:");
foreach (var flight in orderFlight)
{
    Console.WriteLine($"Flight to {flight.Destination}, Duration: {flight.EstamateDuration} hours");
}

fm.DestinationGroupedFlights();