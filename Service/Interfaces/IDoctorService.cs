using MedicationManager.DTO;

namespace MedicationManager.Service.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
    Task<DoctorDTO?> GetByIdAsync(int id);
    Task<DoctorDTO> CreatedAsync(DoctorDTO doctorDto);
    Task<bool> DeleteAsync(int id);
}