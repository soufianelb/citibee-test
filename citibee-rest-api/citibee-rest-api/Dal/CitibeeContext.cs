using System;
using citibee_rest_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace citibee_rest_api.Dal
{
    public partial class CitibeeContext : DbContext
    {
        
        public CitibeeContext(DbContextOptions<CitibeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gebruiker> Gebruiker { get; set; }
        public virtual DbSet<GereserveerdeItem> GereserveerdeItem { get; set; }
        public virtual DbSet<Parkeergarage> Parkeergarage { get; set; }
        public virtual DbSet<ReserveringItem> ReserveringItem { get; set; }
        public virtual DbSet<ReserveringItemType> ReserveringItemType { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Gebruiker>(entity =>
            {
                entity.ToTable("gebruiker");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                      .IsRequired();


                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasColumnName("familienaam")
                    .HasColumnType("character varying");

                entity.Property(e => e.Gebruikersnaam)
                    .IsRequired()
                    .HasColumnName("gebruikersnaam")
                    .HasColumnType("character varying");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasColumnName("voornaam")
                    .HasColumnType("character varying");

                entity.Property(e => e.Wachtwoord)
                    .IsRequired()
                    .HasColumnName("wachtwoord")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<GereserveerdeItem>(entity =>
            {
                entity.ToTable("gereserveerde_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                     .IsRequired();

                entity.Property(e => e.Einddatum).HasColumnName("einddatum");

                entity.Property(e => e.GebruikerId).HasColumnName("gebruiker_id");

                entity.Property(e => e.ReserveringItemId).HasColumnName("reservering_item_id");

                entity.Property(e => e.Startdatum).HasColumnName("startdatum");

                entity.HasOne(d => d.Gebruiker)
                    .WithMany(p => p.GereserveerdeItem)
                    .HasForeignKey(d => d.GebruikerId)
                    .HasConstraintName("fk_gebruiker_id");

                entity.HasOne(d => d.ReserveringItem)
                    .WithMany(p => p.GereserveerdeItem)
                    .HasForeignKey(d => d.ReserveringItemId)
                    .HasConstraintName("fk_reservering_item_id");
            });

            modelBuilder.Entity<Parkeergarage>(entity =>
            {
                entity.ToTable("parkeergarage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .HasColumnName("adres")
                    .HasColumnType("character varying");

                entity.Property(e => e.Lat)
                   .HasColumnName("lat")
                   .HasColumnType("character varying");

                entity.Property(e => e.Lng)
                   .HasColumnName("lng")
                   .HasColumnType("character varying");



                entity.Property(e => e.Geolocatie)
                    .IsRequired()
                    .HasColumnName("geolocatie")
                    .HasColumnType("character varying");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasColumnName("naam")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ReserveringItem>(entity =>
            {
                entity.ToTable("reservering_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasColumnType("character varying");

                entity.Property(e => e.Parkingnr)
              .IsRequired()
              .HasColumnName("parkingnr")
              .HasColumnType("character varying");

                entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");

                entity.Property(e => e.ParkeergarageId).HasColumnName("parkeergarage_id");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.ReserveringItem)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("fk_item_type_id");

                entity.HasOne(d => d.Parkeergarage)
                    .WithMany(p => p.ReserveringItem)
                    .HasForeignKey(d => d.ParkeergarageId)
                    .HasConstraintName("fk_parkeergarage_id");
            });

            modelBuilder.Entity<ReserveringItemType>(entity =>
            {
                entity.ToTable("reservering_item_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasColumnName("naam")
                    .HasColumnType("character varying");
            });
        }
    }
}
