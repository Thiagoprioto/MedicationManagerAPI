using MedicationManager.DTO;
using MedicationManager.Entities;

namespace MedicationManager.Mapper;

public static class MedicationMapper
{
    // Converte DTO para Entidade
    public static MedicationEntity FromDTO(MedicationDTO dto) => new()
    {
        Name = dto.Name,
        Dosage = dto.Dosage,
        Classification = dto.Classification,
        Price = dto.Price,
        DosageQuantityStock = dto.DosageQuantityStock,
        NeedRecipe = dto.NeedRecipe
    };
    
    // Converte Entidade para DTO (Método de Extensão)
    public static MedicationDTO ToDTO(this MedicationEntity entity) => new(
        entity.Id,
        entity.Name,
        entity.Dosage,
        entity.Classification,
        entity.Price,
        entity.DosageQuantityStock,
        entity.NeedRecipe
    );
    
    // Atualiza a Entidade existente com os dados do DTO (Método de Extensão)
    public static void UpdateFromDTO(this MedicationEntity entity, MedicationDTO dto)
    {
        entity.Name = dto.Name;
        entity.Dosage = dto.Dosage;
        entity.Classification = dto.Classification;
        entity.Price = dto.Price;
        entity.DosageQuantityStock = dto.DosageQuantityStock;
        entity.NeedRecipe = dto.NeedRecipe;
    }
}