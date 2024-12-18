using VetClinic.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace VetClinic.DataAccess
{
    public class VetClinicDbContext: DbContext
    {
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<VetClinicEntity> VetClinics { get; set; }
        public DbSet<VetEntity> Vets { get; set; }
        public DbSet<VetWorkSchduleEntity> VetWorkSchdules { get; set; }
        public DbSet<VisitEntity> Visits { get; set; }
        public VetClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<AdminEntity>().HasOne(x => x.VetClinic)
                .WithMany(x => x.Admins)
                .HasForeignKey(x => x.VetClinicID);

            modelBuilder.Entity<ClientEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ClientEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<PetEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PetEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<PetEntity>().HasOne(x => x.Client)
               .WithMany(x => x.Pets)
               .HasForeignKey(x => x.ClientID);

            modelBuilder.Entity<ReviewEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ReviewEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Client)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.ClientID);
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Admin)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.AdminID);

            modelBuilder.Entity<VetClinicEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<VetClinicEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<VetEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<VetEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<VetEntity>().HasOne(x => x.VetClinic)
                          .WithMany(x => x.Vets)
                          .HasForeignKey(x => x.VetClinicID);

            modelBuilder.Entity<VetWorkSchduleEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<VetWorkSchduleEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<VetWorkSchduleEntity>().HasOne(x => x.Vet)
                          .WithMany(x => x.VetWorkSchdules)
                          .HasForeignKey(x => x.VetID);

            modelBuilder.Entity<VisitEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<VisitEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<VisitEntity>().HasOne(x => x.Pet)
                          .WithMany(x => x.Visits)
                          .HasForeignKey(x => x.PetID);
            modelBuilder.Entity<VisitEntity>().HasOne(x => x.Vet)
                         .WithMany(x => x.Visits)
                         .HasForeignKey(x => x.VetID);
        }
    }
}