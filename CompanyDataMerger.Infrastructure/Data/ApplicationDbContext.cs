using CompanyDataMerger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API example if you want to add basic rules:
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Domain)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Name)
                      .HasMaxLength(255);

                entity.Property(e => e.Industry)
                      .HasMaxLength(255);

                entity.Property(e => e.CompanySize)
                      .HasMaxLength(255);

                entity.Property(e => e.Country)
                      .HasMaxLength(255);

                entity.Property(e => e.Location)
                      .HasMaxLength(255);

                entity.Property(e => e.LinkedInId)
                      .HasMaxLength(255);

                entity.Property(e => e.LinkedInUrl)
                      .HasMaxLength(500);

                entity.Property(e => e.Description)
                      .HasColumnType("TEXT");

                entity.Property(e => e.LogoUrl)
                      .HasMaxLength(500);

                entity.Property(e => e.HeadquartersAddress)
                      .HasMaxLength(500);

                entity.Property(e => e.HeadquartersCity)
                      .HasMaxLength(255);

                entity.Property(e => e.HeadquartersZip)
                      .HasMaxLength(50);
            });
        }
    }
}
