using Men_Fashion.Repo.Model;
using Men_Fashion.Repo.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Men_Fashion.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection addUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection addDatabase(this IServiceCollection services)
        {
            services.AddDbContext<MenShopContext>(options => options.UseSqlServer(getConnectionString()));
            return services;
        }

        private static string getConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;

        }
    }
}
