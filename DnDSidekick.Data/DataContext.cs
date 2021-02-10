using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DnDSidekick")
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        public DbSet<Beast> Beasts { get; set; }
        public DbSet<Sense> Senses { get; set; }
        public DbSet<Trait> Traits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beast>()
                        .ToTable("Beasts")
                        .HasKey(k => k.BeastId);

            modelBuilder.Entity<Sense>()
                        .ToTable("Senses")
                        .HasKey(k => k.SenseId);

            modelBuilder.Entity<Trait>()
                        .ToTable("Traits")
                        .HasKey(k => k.TraitId);

            // Fluent API examples
            //modelBuilder.Entity<Course>()
            //            .Property(p => p.Price)
            //            .HasPrecision(9, 2);

            //modelBuilder.Entity<Dormitory>()
            //            .HasKey(k => k.LocationId)
            //            .Property(p => p.Price)
            //            .HasPrecision(9, 2);

            //modelBuilder.Entity<Person>()
            //            .ToTable("Persons")
            //            .Property(p => p.FirstName)
            //            .HasMaxLength(150)
            //            .IsRequired();

            //modelBuilder.Entity<Person>()
            //            .Property(p => p.LastName)
            //            .HasMaxLength(150)
            //            .IsRequired();

            //modelBuilder.Entity<Profession>()
            //            .Property(p => p.Text)
            //            .HasMaxLength(150)
            //            .IsRequired();

            //modelBuilder.Entity<Profession>()
            //            .Property(p => p.TextLt)
            //            .HasMaxLength(150)
            //            .IsRequired();

            //modelBuilder.Entity<Student>()
            //            .HasOptional(d => d.Dormitory)
            //            .WithMany(s => s.Students)
            //            .HasForeignKey(fk => fk.DormitoryId);
        }
    }
}
