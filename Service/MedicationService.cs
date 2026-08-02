using MedicationManager.Context;
using MedicationManager.DTO;
using MedicationManager.Entities;
using MedicationManager.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MedicationManager.Service;

public class MedicationService : IMedicationService
{
    private readonly MedicationManagerContext _context;

    public MedicationService(MedicationManagerContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<MedicationDTO>> GetAllMedicationAsync()
    {
        var medications = await _context.Medications.ToListAsync();

        if (!medications.Any())
        {
            throw new InvalidOperationException("Não existem medicamentos cadastrados.");
        }

        return medications.Select(m => m.ToDTO());
    }

    public async Task<MedicationDTO?> GetByIdAsync(int id)
    {
        var medication = await _context.Medications.FindAsync(id);

        if (medication == null) return null;
        
        return medication.ToDTO();
    }

    public async Task<MedicationDTO> CreateAsync(MedicationDTO medicationDto)
    {
        if (await _context.Medications.AnyAsync(m => m.Name == medicationDto.Name && m.Dosage == medicationDto.Dosage))
        {
            throw new InvalidOperationException($"Já existe um medicamento cadastrado com o nome '{medicationDto.Name}'.");
        }

        
        var medication = MedicationEntity.FromDTO(medicationDto);

        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();
        
        return medication.ToDTO();
    }

    public async Task<MedicationDTO> UpdateAsync(MedicationDTO medicationDto)
    {
        var updateMedication = await _context.Medications.FindAsync(medicationDto.Id);
        
        if (medicationDto == null)
        {
            throw new ArgumentException("Remédio não encontrado.");
        }
        
        updateMedication.UpdateFromDTO(medicationDto);

        await _context.SaveChangesAsync();

        return updateMedication.ToDTO();
    }

    public async Task<MedicationDTO> DeleteAsync(int id)
    {
        var deleteMedication = await _context.Medications.FindAsync(id);
        if (deleteMedication == null)
        {
            throw new InvalidOperationException(id.ToString("Remédio não encontrado"));
        }

        _context.Medications.Remove(deleteMedication);
        await _context.SaveChangesAsync();

        return deleteMedication.ToDTO();
    }
}