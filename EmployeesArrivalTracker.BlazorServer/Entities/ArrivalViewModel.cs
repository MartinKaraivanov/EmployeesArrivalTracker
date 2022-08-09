namespace EmployeesArrivalTracker.BlazorServer.Entities
{
    public class ArrivalViewModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public DateTime ArrivalDatetime { get; set; }
    }
}
