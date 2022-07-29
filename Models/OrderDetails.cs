using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Models
{
    class OrderDetails
    {
        /// <summary>
        /// Order Number
        /// </summary>
        public string orderNumber { get; set; }

        /// <summary>
        /// Status of the order
        /// </summary>
        public int status { get; set; }


        /// <summary>
        /// Flight details
        /// </summary>
        public Flight  flight { get; set; }

        public override string ToString()
        {
            return "order:" + orderNumber + ", flightNumber:" + flight.flightNumber + ", departure: " + flight.departureCity + ", arrival: " + flight.arrivalCity + ", day: " + flight.day;
        }
    }
}
