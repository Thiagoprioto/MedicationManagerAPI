using MedicationManager.Enums;

namespace MedicationManager.DTO.Response;

public record MedicationResponse
(
    int Id,
    string Name,
    string Dosage,
    DrugClassification Classification,
    decimal Price,
    int DosageQuantityStock,
    bool NeedRecipe
);