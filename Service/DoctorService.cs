using MedicationManager.DTO;
using MedicationManager.DTO.Response;
using MedicationManager.Service.Interfaces;

namespace MedicationManager.Service;

public class DoctorService : IDoctorService
{
    public Task<IEnumerable<DoctorResponse>> GetAllDoctorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorResponse> CreatedAsync(CreateDoctorRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}