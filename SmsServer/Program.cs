using SmsServer.Database;
using SmsServer.Database.Model;

namespace SmsServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmsDBContext context = new SmsDBContextFactory().CreateDbContext(args);

            var emp = new Employee { FirstName = "Lukas", LastName = "Kindig" };
            context.Employees.Add(emp);
            context.SaveChanges();
        }
    }
}
