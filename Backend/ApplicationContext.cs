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
        public DbSet<LegalInformation> LegalInformation { set; get; }

        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Message> Messages { set; get; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
           

            builder.Entity<Contact>()
            .HasMany(m1 => m1.Messages)
            .WithOne(m2 => m2.Contact);


            builder.Entity<Contact>()
                   .HasOne<User>(mr => mr.Owner)
                   .WithMany(m3 => m3.Contacts)
                   .HasForeignKey(mr => mr.User);


            //one to one relashionship with legalinformation table
            builder.Entity<User>().HasOne(a => a.LegalInformation)
                                    .WithOne(b => b.User)
                                    .HasForeignKey<LegalInformation>(b => b.User);

            base.OnModelCreating(builder);
        }
    }
}