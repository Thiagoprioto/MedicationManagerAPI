using MedicationManager.DTO;
using MedicationManager.Service.Interfaces;

namespace MedicationManager.Service;

public class DoctorService : IDoctorService
{
    public Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDTO?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDTO> CreatedAsync(DoctorDTO doctorDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}