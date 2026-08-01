using MedicationManager.DTO.Response;
using MedicationManager.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicationManager.Entities;

public class Medication
{
    public int Id { get; set; }
    public required string Name { get; set; } // Ex: Amoxicilina
    public required string Dosage { get; set; } // Ex: 500mg
    public DrugClassification Classification { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int DosageQuantityStock { get; set; }
    public bool NeedRecipe { get; set; }
}