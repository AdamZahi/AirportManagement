using AM.APP.CORE.domain;
using AM.APP.CORE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.Service
{
    public class FlightMethod : IFlightMethod
    {
        public List<Flight> Flights { get; set; }

        public IList<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();
            //for(int i = 0; i< Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        flightDates.Add(Flights[i].FlightDate);
            //    }
            //}
            //foreach (var item in Flights)
            //{
            //    if (item.Destination == destination)
            //    {
            //        flightDates.Add(item.FlightDate);
            //    }
            //}
            //var query = from item in Flights
            //            where item.Destination == destination
            //            select item.FlightDate;
            //return query.ToList();
            return Flights.Where(f => f.Destination == destination)
                          .Select(e => e.FlightDate)
                          .ToList();
        }

        public void GetFlights(string filterType, string filterValue){
               switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}");
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            Console.WriteLine($"Flight from {flight.Departure} on {flight.FlightDate}");
                        }
                    }
                    break;
                case "FlightDate":
                    
                        foreach (var flight in Flights)
                        {
                        if (flight.FlightDate.Date == DateTime.Parse(filterValue))
                            {
                                Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}");
                            }
                        }
                    
                    break;
                case "EffectiveArrival":
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival.Date == DateTime.Parse(filterValue))
                            {
                                Console.WriteLine($"Flight to {flight.Destination} arriving on {flight.EffectiveArrival}");
                            }
                        }
                    break;
                case "EstamateDuration":
                        foreach (var flight in Flights)
                        {
                            if (flight.EstamateDuration == int.Parse(filterValue) )
                            {
                                Console.WriteLine($"Flight to {flight.Destination} with duration {flight.EstamateDuration} minutes");
                            }
                        }
                    break;

                default:
                    Console.WriteLine("Invalid filter type.");
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane == plane
            //            select new { f.FlightDate, f.Destination };
            var query = Flights.Where(f => f.Plane == plane)
                        .Select(e => new { e.FlightDate, e.Destination });
            foreach (var item in query) { 
                Console.WriteLine($"Flight to {item.Destination} on {item.FlightDate}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from f in Flights
            //            where
            //            DateTime.Compare(f.FlightDate, startDate) >= 0
            //            && (f.FlightDate - startDate).TotalDays <= 7
            //            // f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7)
            //            select f;

            //return query.Count();
            return Flights.Count(item => item.FlightDate >= startDate 
            && item.FlightDate <= startDate.AddDays(7));
        }

        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstamateDuration;
            //return query.Average();
            return Flights.Where(f => f.Destination == destination)
                          .Average(f => f.EstamateDuration);
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstamateDuration descending
            //            select f;
            //return query;
            return Flights.OrderByDescending(f => f.EstamateDuration);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = 
            //    from p in flight.Passengers.OfType<Traveller>()
            //            orderby p.BirthDate
            //            select p;

            //return query.Take(3);
            return flight.Passengers.OfType<Traveller>()
                         .OrderBy(p => p.BirthDate)
                         .Take(3);
        }

        public void DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.Destination;
            var query = Flights.GroupBy(f => f.Destination);

            foreach (var group in query)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }
    }
}
