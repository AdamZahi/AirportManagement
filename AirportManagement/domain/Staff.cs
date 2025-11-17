using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APP.CORE.domain
{
    public class Staff:Passanger
    {
        public DateTime employmentDate { get; set; }
        public string function { get; set; }
        public int salary { get; set; }
        public override void passangerType()
        {
            base.passangerType();
            Console.WriteLine("I'm a staff member!");
        }
    }
}
