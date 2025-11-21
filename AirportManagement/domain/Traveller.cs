using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.domain
{
    public class Traveller:Passenger
    {
        public string healthInformation { get; set; }
        public string nationality { get; set; }
    }
}
