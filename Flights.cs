using FlightScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler
{
    class Flights
    {
        private List<Order> _orders;
        private int _numberOfDestinations;
        private int _flightCapacity = 20;
        private List<OrderDetails> _ordersDetails = new List<OrderDetails>();
        public Flights(List<Order> orders)
        { 
            _orders = orders;
            _numberOfDestinations = orders.GroupBy(x => x.destinationCity).Count();
        }

        public List<Flight> GetFlightSchedule()
        {
            List<Flight> flights = new List<Flight>();
            int flightCount = 0;
            foreach (var order in _orders)
            {
                if (flights.Count != 0 && flights.Any(x => x.arrivalCity == order.destinationCity))
                {
                    var flight = flights.FirstOrDefault(x => x.arrivalCity == order.destinationCity && x.load < _flightCapacity);
                    flight.load += 1;

                    if (flight.load == _flightCapacity) 
                    {
                        flights.Add(new Flight
                        {
                            arrivalCity = order.destinationCity,
                            day = 2,
                            load = 1,
                            flightNumber = flightCount + _numberOfDestinations
                        }) ;
                    }
                }
                else 
                {
                    flightCount++;
                    flights.Add(new Flight { 
                        arrivalCity = order.destinationCity,
                        day = 1,
                        load = 1,
                        flightNumber = flightCount
                    });
                }
            }

            flights.ForEach(x => x.load = 0);
            flights = flights.OrderBy(x => x.flightNumber).ToList();
            return flights;
        }

        public List<OrderDetails> GetOrderDetails(List<Flight> flights)
        {   
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (var order in _orders)
            {
                if (flights.Count != 0 && flights.Any(x => x.arrivalCity == order.destinationCity))
                {
                    var flight = flights.FirstOrDefault(x => x.arrivalCity == order.destinationCity && x.load < _flightCapacity);
                    flight.load += 1;
                    orderDetails.Add(new OrderDetails()
                    {
                        flight = flight,
                        orderNumber = order.orderNumber,
                        status = 1
                    });
                }
            }
            return orderDetails;
        }
    }
}
