using Hospital.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data;

public class HospitalContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Hospitalization> Hospitalizations { get; set; }
    public DbSet<Measure> Measures { get; set; }
    public DbSet<MeasureType> MeasureTypes { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<Policy> Policies { get; set; }

    public HospitalContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HospitalTest;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasureType>()
            .Property(m => m.Cost)
            .HasColumnType("decimal(18, 6)"); // Указываем тип столбца и точность
    }

}
