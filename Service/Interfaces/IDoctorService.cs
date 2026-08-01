using MedicationManager.DTO;
using MedicationManager.DTO.Response;
using MedicationManager.Entities;

namespace MedicationManager.Service.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<DoctorResponse>> GetAllDoctorsAsync();
    Task<DoctorResponse?> GetByIdAsync(int id);
    Task<DoctorResponse> CreatedAsync(CreateDoctorRequest request);
    Task<bool> DeleteAsync(int id);
}