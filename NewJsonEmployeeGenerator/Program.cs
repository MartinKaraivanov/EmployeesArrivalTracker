using System.Text.Json;

namespace NewJsonEmployeeGenerator;

public class Employee
{
    public int Id { get; set; }
    public int? ManagerId { get; set; }
    public int Age { get; set; }
    public IEnumerable<string>? Teams { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? SurName { get; set; }
    public string? Name { get; set; }
}

public class Program
{
    private static readonly string[] roles = new string[] { "Junior Developer", "Semi Senior Developer", "Senior Developer", "Principal", "Team Leader" };
    private static readonly string[] teams = new string[] { "Platform", "Sales", "Billing", "Mirage" };

    private static Random generator = new Random();

    static Employee getEmployee(string line, int lineCounter)
    {

        int? managerId = null;
        var employeeTeams = Enumerable.Empty<string>();
        string? role = "Manager";

        if (lineCounter >= 11)
        {
            managerId = generator.Next(11);

            int count = generator.Next(1, 4);
            employeeTeams = Enumerable.Range(0, count).Select(_ => teams[generator.Next(4)]);

            role = roles[generator.Next(4)];
        }

        Employee employee = new Employee
        {
            Id = lineCounter,
            ManagerId = managerId,
            Age = generator.Next(18, 66),
            Teams = employeeTeams,
            Role = role,
            Email = line.Split('\t')[2],
            SurName = line.Split('\t')[1],
            Name = line.Split('\t')[0]
        };

        return employee;
    }
    public static void Main()
    {
        string readFileName = @"C:\Prj\Fourth\EmployeesArrivalTracker\NewJsonEmployeeGenerator\employees.txt";
        string jsonFileName = @"C:\Prj\Fourth\EmployeesArrivalTracker\NewJsonEmployeeGenerator\employees.json";

        var query = File.ReadLines(readFileName).Select(getEmployee);

        using FileStream resultStream = File.Create(jsonFileName);
        JsonSerializer.Serialize(resultStream, query, new JsonSerializerOptions { WriteIndented = true });
    }
}
