using Microsoft.EntityFrameworkCore;
using Repositories;

namespace OnlineMarketApp.Infrastructere.Extensions
{
    public static class ApplicationExtension
    {
        // Migrations işlemleri için
        public static void ConfigureAndCheckMigration(this ApplicationBuilder app)
        {
            RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        // Localization işlemleri için.
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }
    }
}