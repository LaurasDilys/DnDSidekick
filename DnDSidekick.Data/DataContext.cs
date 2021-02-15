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

        public DbSet<MonsterDataModel> Monsters { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Environ> Environs { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonsterDataModel>()
                        .ToTable("Monsters")
                        .HasKey(k => k.MonsterId);

            modelBuilder.Entity<Trait>()
                        .ToTable("Traits")
                        .HasKey(k => k.Id);
            modelBuilder.Entity<MonsterDataModel>()
                        .HasMany<Trait>(m => m.Traits)
                        .WithMany(t => t.Monsters)
                        .Map(mt =>
                        {
                            mt.MapLeftKey("MonsterId");
                            mt.MapRightKey("TraitId");
                            mt.ToTable("MonsterTraits");
                        });

            modelBuilder.Entity<Language>()
                        .ToTable("Languages")
                        .HasKey(k => k.Id);
            modelBuilder.Entity<MonsterDataModel>()
                        .HasMany<Language>(m => m.Languages)
                        .WithMany(l => l.Monsters)
                        .Map(ml =>
                        {
                            ml.MapLeftKey("MonsterId");
                            ml.MapRightKey("LanguageId");
                            ml.ToTable("MonsterLanguages");
                        });

            modelBuilder.Entity<Environ>()
                        .ToTable("Environs")
                        .HasKey(k => k.Id);
            modelBuilder.Entity<MonsterDataModel>()
                        .HasMany<Environ>(m => m.Environs)
                        .WithMany(e => e.Monsters)
                        .Map(me =>
                        {
                            me.MapLeftKey("MonsterId");
                            me.MapRightKey("EnvironId");
                            me.ToTable("MonsterEnvirons");
                        });

            modelBuilder.Entity<MonsterDataModel>()
                        .HasOptional<Tag>(m => m.Tag)
                        .WithMany(t => t.Monsters);



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
