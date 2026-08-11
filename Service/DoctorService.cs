using MedicationManager.Context;
using MedicationManager.DTO;
using MedicationManager.Mapper;
using MedicationManager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicationManager.Service;

public class DoctorService : IDoctorService
{
    private readonly MedicationManagerContext _context;

    public DoctorService(MedicationManagerContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
    {
        var doctors = await _context.Doctors.ToListAsync();

        return doctors.Select(d => d.ToDTO());
    }

    public async Task<DoctorDTO?> GetByIdAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return null;
        
        return doctor.ToDTO();
    }

    public async Task<DoctorDTO> CreatedAsync(DoctorDTO doctorDto)
    {
        if (await _context.Doctors.AnyAsync(d => d.Name == doctorDto.Name && d.Crm == doctorDto.Crm ))
        {
            throw new InvalidOperationException
                ($"Já existe um médico cadastrado com esses dados'{doctorDto.Name}' - '{doctorDto.Crm}'.");
        }

        
        var doctor = DoctorMapper.FromDTO(doctorDto);

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        
        return doctor.ToDTO();
    }

    public async Task<DoctorDTO> UpdatedAsync(DoctorDTO doctorDto)
    {
        var updateDoctor = await _context.Doctors.FindAsync(doctorDto.Id);
        
        if (updateDoctor == null)
        {
            throw new InvalidOperationException("Médico não encontrado.");
        }
        
        updateDoctor.UpdateFromDTO(doctorDto);

        await _context.SaveChangesAsync();

        return updateDoctor.ToDTO();
    }

    public async Task<DoctorDTO> DeleteAsync(int id)
    {
        var deleteDoctor = await _context.Doctors.FindAsync(id);
        if (deleteDoctor == null)
        {
            throw new InvalidOperationException(id.ToString("Médico não encontrado"));
        }
        
        _context.Doctors.Remove(deleteDoctor);
        await _context.SaveChangesAsync();

        return deleteDoctor.ToDTO();
    }
}