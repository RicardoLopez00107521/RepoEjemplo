using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Models;

namespace AppointmentSystem.Data
{
    public class AppointmentSystemDbContext : DbContext
    {
        public AppointmentSystemDbContext(DbContextOptions<AppointmentSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles")
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .ToTable("Appointments");

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(u => u.AppointmentsAsDoctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.AppointmentsAsPatient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData
            (
                new Role { RoleId = 1, RoleName = "Doctor" },
                new Role { RoleId = 2, RoleName = "Paciente" },
                new Role { RoleId = 3, RoleName = "Administrador" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}