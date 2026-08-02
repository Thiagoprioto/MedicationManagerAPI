using MedicationManager.DTO;

namespace MedicationManager.Service.Interfaces;

public interface IMedicationService
{
    Task<IEnumerable<MedicationDTO>> GetAllMedicationAsync();
    Task<MedicationDTO?> GetByIdAsync(int id);
    Task<MedicationDTO> CreateAsync(MedicationDTO medicationDto);
    Task<MedicationDTO> UpdateAsync(MedicationDTO medicationDto);
    Task<MedicationDTO> DeleteAsync(int id);
}