using MedicationManager.Entities;
using MedicationManager.Enums;
namespace MedicationManager.DTO;

public record CreateMedicationRequest
(
    string Name, // Ex: Amoxicilina
    string Dosage, // Ex: 500mg
    DrugClassification Classification,
    decimal Price,
    int DosageQuantityStock,
    bool NeedRecipe
);