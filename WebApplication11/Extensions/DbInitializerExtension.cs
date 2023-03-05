using WebApplication11.Data;
using WebApplication11.model;

namespace WebApplication11.Extensions
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ContactsAPIDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                throw ;
            }

            return app;
        }
    }
    internal class DbInitializer
    {
        internal static void Initialize(ContactsAPIDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Contacts.Any()) return;

            var contacts = new Contact[]
            {
             new Contact() {
                       Id = Guid.NewGuid(),
                       Name = "Amit",
                       Address = "Crawley",
                       email = "amit@test.com",
                       phone = 7342140120,
                   },
                   new Contact()
                   {
                       Id = Guid.NewGuid(),
                       Name = "Dhananjay",
                       Address = "Glasgow",
                       email = "dhananjay@test.com",
                       phone = 7342140122,
                   }

            //add other users
            };

            foreach (var contact in contacts)
                dbContext.Contacts.Add(contact);

            dbContext.SaveChanges();
        }
    }
}
