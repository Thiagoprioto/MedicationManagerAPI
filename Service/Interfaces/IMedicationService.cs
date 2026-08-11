using MedicationManager.DTO;

namespace MedicationManager.Service.Interfaces;

public interface IMedicationService
{
    Task<IEnumerable<MedicationDTO>> GetAllMedicationAsync();
    Task<MedicationDTO?> GetByIdAsync(int id);
    Task<MedicationDTO> CreatedAsync(MedicationDTO medicationDto);
    Task<MedicationDTO> UpdatedAsync(MedicationDTO medicationDto);
    Task<MedicationDTO> DeleteAsync(int id);
}