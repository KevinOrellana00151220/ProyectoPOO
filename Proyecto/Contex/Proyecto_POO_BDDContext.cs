using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proyecto.Models
{
    public partial class Proyecto_POO_BDDContext : DbContext
    {
        public Proyecto_POO_BDDContext()
        {
        }

        public Proyecto_POO_BDDContext(DbContextOptions<Proyecto_POO_BDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<ChronicDisease> ChronicDiseases { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ManagementAccount> ManagementAccounts { get; set; }
        public virtual DbSet<ManagementLogin> ManagementLogins { get; set; }
        public virtual DbSet<Obserbation> Obserbations { get; set; }
        public virtual DbSet<Ocupation> Ocupations { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Proyecto_POO_BDD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AssistanceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("assistance_date");

                entity.Property(e => e.IdCitizen).HasColumnName("id_citizen");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdVaccination).HasColumnName("id_vaccination");

                entity.Property(e => e.IdVaccine).HasColumnName("id_vaccine");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reservation_date");

                entity.Property(e => e.VaccinationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("vaccination_date");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_ci__3B75D760");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_em__3C69FB99");

                entity.HasOne(d => d.IdVaccineNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdVaccine)
                    .HasConstraintName("FK__APPOINTME__id_va__3D5E1FD2");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Cabins)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CABIN__id_employ__4316F928");
            });

            modelBuilder.Entity<ChronicDisease>(entity =>
            {
                entity.ToTable("CHRONIC_DISEASES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CommonName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("common_name");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("CITIZEN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.IdChronicDiseases).HasColumnName("id_chronic_diseases");

                entity.Property(e => e.IdOccupation).HasColumnName("id_occupation");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.HasOne(d => d.IdChronicDiseasesNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdChronicDiseases)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_chro__398D8EEE");

                entity.HasOne(d => d.IdOccupationNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdOccupation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_occu__3A81B327");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Addresses)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("addresses");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.IdManagementAccount).HasColumnName("id_management_account");

                entity.Property(e => e.Job)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("job");

                entity.HasOne(d => d.IdManagementAccountNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdManagementAccount)
                    .HasConstraintName("FK__EMPLOYEE__id_man__403A8C7D");
            });

            modelBuilder.Entity<ManagementAccount>(entity =>
            {
                entity.ToTable("MANAGEMENT_ACCOUNT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PasswordManagement)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("password_management");

                entity.Property(e => e.UserManagement)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_management");
            });

            modelBuilder.Entity<ManagementLogin>(entity =>
            {
                entity.ToTable("MANAGEMENT_LOGIN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("date_hour");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.ManagementLogins)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANAGEMEN__id_ca__440B1D61");
            });

            modelBuilder.Entity<Obserbation>(entity =>
            {
                entity.HasKey(e => new { e.IdAppointment, e.IdSymptom })
                    .HasName("PK__OBSERBAT__C2F4CA7B41F4BF20");

                entity.ToTable("OBSERBATION");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.Property(e => e.IdSymptom).HasColumnName("id_symptom");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.Obserbations)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OBSERBATI__id_ap__3E52440B");

                entity.HasOne(d => d.IdSymptomNavigation)
                    .WithMany(p => p.Obserbations)
                    .HasForeignKey(d => d.IdSymptom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OBSERBATI__id_sy__3F466844");
            });

            modelBuilder.Entity<Ocupation>(entity =>
            {
                entity.ToTable("OCUPATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CommonName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("common_name");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => new { e.IdEmployee, e.IdManagementLogin })
                    .HasName("PK__RECORD__60468A5BBE8A8FF2");

                entity.ToTable("RECORD");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdManagementLogin).HasColumnName("id_management_login");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RECORD__id_emplo__412EB0B6");

                entity.HasOne(d => d.IdManagementLoginNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdManagementLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RECORD__id_manag__4222D4EF");
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("SYMPTOM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CommonName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("common_name");

                entity.Property(e => e.ReactionTime).HasColumnName("reaction_time");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("VACCINE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Vaccine1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VACCINE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
