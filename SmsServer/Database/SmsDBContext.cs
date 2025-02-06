using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmsServer.Database
{
    internal class SmsDBContext : DbContext
    {
        public SmsDBContext(DbContextOptions<SmsDBContext> options) : base(options) { }
        public DbSet<Model.Employee> Employees { get; set; }
    }

    internal class SmsDBContextFactory : IDesignTimeDbContextFactory<SmsDBContext>
    {
        public SmsDBContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder appConfigBuilder = new ConfigurationBuilder();
            appConfigBuilder.SetBasePath(Directory.GetCurrentDirectory());
            appConfigBuilder.AddJsonFile("AppSettings.json", false /*Required*/, true /*Auto-Reload*/);
            IConfigurationRoot appConfig = appConfigBuilder.Build();

            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<SmsDBContext>(options => options.UseNpgsql(appConfig.GetConnectionString("DefaultConnection")));
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IServiceScope scope = serviceProvider.CreateScope();

            SmsDBContext context = scope.ServiceProvider.GetRequiredService<SmsDBContext>();
            return context;
        }
    }
}
