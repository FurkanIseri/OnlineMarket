using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

namespace OnlineMarketApp.Infrastructere.Extensions
{
    public static class ServiceExtension
    {
        // Veritabanı bağlantısı
        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
               options.UseSqlite(configuration.GetConnectionString("sqlLiteConnection"),
               b => b.MigrationsAssembly("OnlineMarketApp")); 

               options.EnableSensitiveDataLogging(true);// Log kayıtları
            });
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "OnlineMarketApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager,RepositoryManager>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServicerManager,ServiceManager>();
            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
        }
        public static void ConfigurRooting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
               options.LowercaseUrls = true; 
               options.AppendTrailingSlash = true; 
            });
        }
    }
}