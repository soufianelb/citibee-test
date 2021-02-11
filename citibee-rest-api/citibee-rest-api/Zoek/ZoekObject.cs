using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Zoek
{
    public class ZoekObject
    {
        public DateTime Begintijd { get; set; }
        public DateTime Eindtijd { get; set; }
        public int ParkingId { get; set; }
    }
}
