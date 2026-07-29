using System.ComponentModel.DataAnnotations;
using MedicationManager.Entities;

namespace MedicationManager.Context;
using Microsoft.EntityFrameworkCore;

public class MedicationManagerContext : DbContext
{
    public MedicationManagerContext(DbContextOptions<MedicationManagerContext> options) : base(options)
    {
        
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medication> Medications { get; set; }
}