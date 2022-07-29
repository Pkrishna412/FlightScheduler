using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightScheduler.Enums;

namespace FlightScheduler.Models
{
    class Order
    {
        public string orderNumber { get; set; }

        public Airports destinationCity { get; set; }
    }
}
