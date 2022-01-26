using Chatty.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatty.Core
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Message> Messages { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}