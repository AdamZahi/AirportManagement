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
    }
}
