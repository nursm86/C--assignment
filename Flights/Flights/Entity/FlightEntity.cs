using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Entity
{
    public class FlightEntity
    {
        public int Id { get; set; }
        public string FlightName { get; set; }
        public DateTime TakeOffTime { get; set; }
    }
}
