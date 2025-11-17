using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }    
        public DateTime EffectiveArrival { get; set; }
        public int EstamateDuration { get; set; }
        public Plane Plane { get; set; }
    }
}
