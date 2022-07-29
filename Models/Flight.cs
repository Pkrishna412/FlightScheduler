using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightScheduler.Enums;

namespace FlightScheduler.Models
{
    class Flight
    {
        /// <summary>
        /// Flight Number
        /// </summary>
        public int flightNumber { get; set; }

        /// <summary>
        /// Departure City
        /// </summary>
        public Airports departureCity { get; set; } = Airports.YUL;

        /// <summary>
        /// Arrival City
        /// </summary>
        public Airports arrivalCity { get; set; }

        /// <summary>
        /// Day of journey
        /// </summary>
        public int day { get; set; }

        /// <summary>
        /// Load of the flight
        /// </summary>
        public int load { get; set; }

        public override string ToString()
        {
            return "Flight:" + flightNumber + ", departure: " + departureCity + ", arrival: " + arrivalCity + ", day: " + day;
        }
    }
}
