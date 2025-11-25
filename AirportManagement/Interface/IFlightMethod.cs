using AM.APP.CORE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.Interface
{
    public interface IFlightMethod
    {
        public IList<DateTime> GetFlightDates(string destination);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);

        public IEnumerable<Flight> OrderedDurationFlights();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        public void DestinationGroupedFlights();
    }
}
