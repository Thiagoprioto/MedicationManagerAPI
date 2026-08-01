using MedicationManager.DTO;
using MedicationManager.DTO.Response;

namespace MedicationManager.Service.Interfaces;

public interface IMedicationService
{
    Task<IEnumerable<MedicationResponse>> GetAllMedicationAsync();
    Task<MedicationResponse?> GetByIdAsync(int id);
    Task<MedicationResponse> CreatedAsync(CreateMedicationRequest  request);
    Task<bool> UpdateStockAsync(int id, int quantity);
}