using FlightScheduler;
using FlightScheduler.Enums;
using FlightScheduler.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class program
{
    public static void Main()
    {
        List<Order> orders = new List<Order>();
        List<Flight> flightSchedule;
        string fileName = "coding-assigment-orders.json"; 
        var relativePath = Path.Combine(".", "C:\\Users\\Pavan\\source\\repos\\FlightScheduler", fileName);
        orders = LoadOrders(relativePath);
        Flights flight = new Flights(orders);
        flightSchedule = flight.GetFlightSchedule();

        Console.WriteLine("FLIGHT SCHEDULE : ");
        foreach (Flight item in flightSchedule)
        { 
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();
        var orderDetails = flight.GetOrderDetails(flightSchedule);
        Console.WriteLine("ORDER DETAILS : ");
        foreach (OrderDetails item in orderDetails)
        {
            Console.WriteLine(item.ToString());
        }

        Console.ReadLine();
    }

    private static List<Order> LoadOrders(string fileName)
    {
        using (StreamReader r = new StreamReader(fileName))
        {
            List<Order> orders = new List<Order>();
            string json = r.ReadToEnd();
            JObject data = (JObject)JsonConvert.DeserializeObject(json);
            foreach (var item in data)
            {
                var order = new Order();
                order.orderNumber = item.Key;
                Enum.TryParse(item.Value.First.First.ToString(), out Airports destination);
                order.destinationCity = destination;
                orders.Add(order);
            }
            
            return orders;
        }
    }
}