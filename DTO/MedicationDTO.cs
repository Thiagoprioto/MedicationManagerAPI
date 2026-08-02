using MedicationManager.Enums;

namespace MedicationManager.DTO;

public record MedicationDTO
(
    int Id,
    string Name,
    string Dosage,
    DrugClassification Classification,
    decimal Price,
    int DosageQuantityStock,
    bool NeedRecipe
);