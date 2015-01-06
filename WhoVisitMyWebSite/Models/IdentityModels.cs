using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace WhoVisitMyWebSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class Client
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string IP { get; set; }

        public string Comment { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}