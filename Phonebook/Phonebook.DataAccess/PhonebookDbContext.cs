using System.Data.Entity;
using Phonebook.DataAccess.Models;

namespace Phonebook.DataAccess
{
    public class PhonebookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        
        public PhonebookDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<Contact>()
                .Property(c => c.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .Property(c => c.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .Property(c => c.PhoneNumber)
                .HasMaxLength(30);

            base.OnModelCreating(modelBuilder);
        }
    }
}