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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(modelBuilder);
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

          

            //CategorieIngrediente-Ingrediente
           

            builder.Entity<Contact>()
            .HasMany(m1 => m1.Messages)
            .WithOne(m2 => m2.Contact);



            // Many to Many

            builder.Entity<Contact>()
                   .HasOne<User>(mr => mr.Owner)
                   .WithMany(m3 => m3.Contacts)
                   .HasForeignKey(mr => mr.User);


            base.OnModelCreating(builder);
        }
    }
}