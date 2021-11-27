using System;
using System.Collections.Generic;

namespace SalesWebApi.Models
{
    public partial class Login
    {
        public Login()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
