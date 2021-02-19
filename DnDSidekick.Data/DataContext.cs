using DnDSidekick.Business.Interfaces;
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
        public DbSet<Size> Sizes { get; set; }
        public DbSet<CreatureType> Types { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Environ> Environs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CharacterDataModel> Characters { get; set; }
        public DbSet<CharacterSave> CharacterSaveHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonsterDataModel>()
                        .ToTable("Monsters")
                        .HasKey(k => k.MonsterId);

            modelBuilder.Entity<CreatureType>()
                        .ToTable("Types");

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



            modelBuilder.Entity<CharacterDataModel>()
                        .ToTable("Characters")
                        .HasKey(k => k.Id);

            modelBuilder.Entity<CharacterSave>()
                        .ToTable("CharacterSaveHistory")
                        .HasKey(k => k.Id);
        }
    }
}
