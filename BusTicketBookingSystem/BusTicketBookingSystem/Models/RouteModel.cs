using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}