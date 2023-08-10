using Microsoft.EntityFrameworkCore;
using MorgueTrackerMVC.Models;

public class MorgueTrackerContext : DbContext
{
    public MorgueTrackerContext(DbContextOptions<MorgueTrackerContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Release> Releases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<Release>()
            .HasOne(r => r.Patient)  // Configure the relationship with Patient
            .WithMany()
            .HasForeignKey(r => r.PatientID);


        modelBuilder.Entity<Release>()
            .HasOne(r => r.OutEmployee)  // Configure the relationship with Employee for OutEmployee
            .WithMany()
            .HasForeignKey(r => r.OutEmployeeID);

        base.OnModelCreating(modelBuilder);
    }
}
