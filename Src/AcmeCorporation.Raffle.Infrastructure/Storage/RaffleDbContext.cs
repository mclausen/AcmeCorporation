using System;
using AcmeCorporation.Raffle.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcmeCorporation.Raffle.Infrastructure.Storage
{
    public class RaffleDbContext : DbContext
    {
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<RaffleSubmission> RaffleSubmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SerialNumber
            modelBuilder.Entity<SerialNumber>()
                .HasKey(model => model.Serial);

            modelBuilder.Entity<SerialNumber>()
                .Property(model => model.DateCreatedUtc)
                .HasDefaultValue(DateTime.UtcNow);
            
            // Raffle Submission
            modelBuilder.Entity<RaffleSubmission>()
                .HasKey(model => model.Id);
            
            modelBuilder.Entity<RaffleSubmission>()
                .Property(model => model.FirstName)
                .IsRequired();
            
            modelBuilder.Entity<RaffleSubmission>()
                .Property(model => model.LastName)
                .IsRequired();
            
            modelBuilder.Entity<RaffleSubmission>()
                .Property(model => model.FirstName)
                .IsRequired();

            // Converts the value object to column to avoid creating a table just for email addresses
            var converter = new ValueConverter<EmailAddress, string>(
                model => model.Value,
                model => new EmailAddress(model));

            modelBuilder.Entity<RaffleSubmission>()
                .Property(model => model.EmailAddress)
                .HasConversion(converter);
        }
    }
}