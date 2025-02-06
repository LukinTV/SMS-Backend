using SmsServer.Database;

namespace SmsServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmsDBContext context = new SmsDBContextFactory().CreateDbContext(args);
        }
    }
}
