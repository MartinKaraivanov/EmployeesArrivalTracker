using System;
using System.Collections.Generic;

namespace EmployeesArrivalTracker.BlazorServer.Entities
{
    public partial class Arrival
    {
        public int EmployeeId { get; set; }
        public DateTime ArrivalDatetime { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
