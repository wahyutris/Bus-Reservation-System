using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTicketBookingSystem.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DisplayName("Role")]
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // Buat dropdown list yang akan dipake di controller dan view
        public IEnumerable<SelectListItem> Roles { get; set; }
        public UserRoleModel()
        {
            Roles = new List<SelectListItem>();
        }

    }
}