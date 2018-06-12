using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProviderService.data.models;

namespace ProviderService.data.contexts
{    
    public class ProviderContext : DbContext
    {
        
        public ProviderContext(){

        }

        public ProviderContext(DbContextOptions<ProviderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbuPhysician> TbuPhysician { get; set; }
        public virtual DbSet<TbuProvider> TbuProvider { get; set; }

        public virtual DbSet<TbuFacility> TbuFacility {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:d-wbdb01-aultcare.database.windows.net,1433;Initial Catalog=ACProvDir;User Id=ProvDirUser;Password=vOTQ%R!fE$33u!1X;Encrypt=True;TrustServerCertificate=False;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbuPhysician>(entity =>
            {
                entity.HasKey(e => e.PhysicianId);

                entity.ToTable("tbu_Physician", "provdir");

                entity.HasIndex(e => new { e.FirstName, e.MiddleName, e.LastName, e.Gender })
                    .HasName("idx_Physician_Name_Gender");

                entity.Property(e => e.PhysicianId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("Middle_Name")
                    .HasMaxLength(25);

                entity.Property(e => e.Npi)
                    .HasColumnName("NPI")
                    .HasMaxLength(50);

                entity.Property(e => e.ProviderCredential).HasMaxLength(255);

                entity.Property(e => e.Suffix).HasMaxLength(10);
            });
            
             modelBuilder.Entity<TbuProvider>(entity =>
            {
                entity.HasKey(e => e.PhysicianId);

                entity.ToTable("tbu_Provider", "provdir");

                entity.Property(e => e.PhysicianId).ValueGeneratedNever();

                entity.Property(e => e.Deanumber)
                    .IsRequired()
                    .HasColumnName("DEANumber")
                    .HasMaxLength(11);

                entity.Property(e => e.ProviderStatus)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.ProviderType)
                    .IsRequired()
                    .HasMaxLength(9);
            });

             modelBuilder.Entity<TbuFacility>(entity =>
            {
                entity.HasKey(e => e.FacilityId);

                entity.ToTable("tbu_Facility", "provdir");

                entity.HasIndex(e => e.PhysicianId)
                    .HasName("idx_Facility_PhysicianId");

                entity.Property(e => e.FacilityId).ValueGeneratedNever();

                entity.Property(e => e.FacilityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(255);
            });
        }
    }
}

