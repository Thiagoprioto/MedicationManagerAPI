using System.ComponentModel.DataAnnotations;
using MedicationManager.Entities;

namespace MedicationManager.Context;
using Microsoft.EntityFrameworkCore;

public class MedicationManagerContext : DbContext
{
    public MedicationManagerContext(DbContextOptions<MedicationManagerContext> options) : base(options)
    {
        
    }

    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<MedicationEntity> Medications { get; set; }
}