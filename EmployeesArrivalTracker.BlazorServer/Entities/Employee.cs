using System;
using System.Collections.Generic;

namespace EmployeesArrivalTracker.BlazorServer.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Arrivals = new HashSet<Arrival>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<Arrival> Arrivals { get; set; }
    }
}
