using Microsoft.EntityFrameworkCore;
using MorgueTrackerMVC.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

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
        // Configure relationships and any other model configurations here
        modelBuilder.Entity<Release>()
            .HasOne(r => r.Patient)
            .WithMany(p => p.Releases)
            .HasForeignKey(r => r.PatientID);

        modelBuilder.Entity<Release>()
            .HasOne(r => r.InEmployee)
            .WithMany(e => e.InReleases)
            .HasForeignKey(r => r.InEmployeeID);

        modelBuilder.Entity<Release>()
            .HasOne(r => r.OutEmployee)
            .WithMany(e => e.OutReleases)
            .HasForeignKey(r => r.OutEmployeeID);
    }
}
