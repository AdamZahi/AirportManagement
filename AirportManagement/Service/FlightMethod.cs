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
            var query = from item in Flights
                        where item.Destination == destination
                        select item.FlightDate;
            return query.ToList();
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
            var query = from f in Flights
                        where f.Plane == plane
                        select new { f.FlightDate, f.Destination };
            foreach (var item in query) { 
                Console.WriteLine($"Flight to {item.Destination} on {item.FlightDate}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7)
                        select f;
            return query.Count();
        }

        public double DurationAverage(string destination)
        {
            var query = from f in Flights
                        where f.Destination == destination
                        select f.EstamateDuration;
            return query.Average();
        }

        public IList<Flight> OrderedDurationFlights()
        {
            var query = from f in Flights
                        orderby f.EstamateDuration descending
                        select f;
            return query.ToList();
        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.BirthDate
                        select p;

            return query.Take(3).ToList();
        }


        public IList<Flight> DestinationGroupedFlights()
        {
            var query = from f in Flights
                        orderby f.Destination
                        group f by f.Destination;
            List<Flight> groupedFlights = new List<Flight>();
            foreach (var group in query)
            {
                Console.WriteLine($"Destination: {group.Key}");
                foreach (var flight in group)
                {
                    groupedFlights.Add(flight);
                    Console.WriteLine($"\tFlight Date: {flight.FlightDate}");
                }
            }
            return groupedFlights;
        }
    }
}
