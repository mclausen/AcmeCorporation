using System;
using AcmeCorporation.Draw.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcmeCorporation.Draw.Infrastructure.Storage
{
    public class DrawDbContext : DbContext
    {
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<DrawSubmission> RaffleSubmissions { get; set; }

        public DrawDbContext()
        {
            
        }
        
        public DrawDbContext(DbContextOptions<DrawDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SerialNumber
            modelBuilder.Entity<SerialNumber>()
                .HasKey(model => model.Serial);

            modelBuilder.Entity<SerialNumber>()
                .Property(model => model.DateCreatedUtc)
                .IsRequired();
            modelBuilder.Entity<SerialNumber>()
                .Property(model => model.UsageCount)
                .HasDefaultValue(0);
            
            // Raffle Submission
            modelBuilder.Entity<DrawSubmission>()
                .HasKey(model => model.Id);
            
            modelBuilder.Entity<DrawSubmission>()
                .Property(model => model.FirstName)
                .IsRequired();
            
            modelBuilder.Entity<DrawSubmission>()
                .Property(model => model.LastName)
                .IsRequired();
            
            modelBuilder.Entity<DrawSubmission>()
                .Property(model => model.FirstName)
                .IsRequired();

            // Converts the value object to column to avoid creating a table just for email addresses
            var converter = new ValueConverter<EmailAddress, string>(
                model => model.Value,
                model => new EmailAddress(model));

            modelBuilder.Entity<DrawSubmission>()
                .Property(model => model.EmailAddress)
                .HasConversion(converter)
                .IsRequired();
        }
    }
}