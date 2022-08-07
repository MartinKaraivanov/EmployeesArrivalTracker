using System;
using System.Collections.Generic;

namespace EmployeesArrivalTracker.BlazorServer.Data
{
    public partial class Arrival
    {
        public int EmployeeId { get; set; }
        public DateTime ArrivalDatetime { get; set; }
    }
}
