﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusTicketBookingSystem.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public int OriginID { get; set; }
        public int DestinationID { get; set; }
    }
}