using MedicationManager.DTO;
using MedicationManager.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicationManager.Entities;

public class MedicationEntity
{
    // Retorno alterado para MedicationEntity (pois é a entidade que estamos criando!)
    public static MedicationEntity FromDTO(MedicationDTO dto) => new()
    {
        Name = dto.Name,
        Dosage = dto.Dosage,
        Classification = dto.Classification,
        Price = dto.Price,
        DosageQuantityStock = dto.DosageQuantityStock,
        NeedRecipe = dto.NeedRecipe
    };
    
    public MedicationDTO ToDTO() => new(
        Id,
        Name,
        Dosage,
        Classification,
        Price,
        DosageQuantityStock,
        NeedRecipe
    );
    
    public void UpdateFromDTO(MedicationDTO dto)
    {
        Name = dto.Name;
        Dosage = dto.Dosage;
        Classification = dto.Classification;
        Price = dto.Price;
        DosageQuantityStock = dto.DosageQuantityStock;
        NeedRecipe = dto.NeedRecipe;
    }

    public int Id { get; set; }
    public required string Name { get; set; } // Ex: Amoxicilina
    public required string Dosage { get; set; } // Ex: 500mg
    public DrugClassification Classification { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int DosageQuantityStock { get; set; }
    public bool NeedRecipe { get; set; }
}