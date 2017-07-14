using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Models
{
    public class BusVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AC { get; set; }
        public int Fare { get; set; }

        [DisplayName("Departure Time")]
        public DateTime DepartureTime { get; set; }

        public int RouteID { get; set; }
    }
}