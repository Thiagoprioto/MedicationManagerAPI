using System.Text.RegularExpressions;
using MedicationManager.Context;
using MedicationManager.DTO;
using MedicationManager.DTO.Response;
using MedicationManager.Entities;
using MedicationManager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicationManager.Service;

public class MedicationService : IMedicationService
{
    private readonly MedicationManagerContext _context;

    public MedicationService(MedicationManagerContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<MedicationResponse>> GetAllMedicationAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<MedicationResponse?> GetByIdAsync(int id)
    {
        var medication = await _context.Medications.FindAsync(id);
        if (medication == null)
        {
            return null;
        }

        return new MedicationResponse(
            medication.Id,
            medication.Name,
            medication.Dosage,
            medication.Classification,
            medication.Price,
            medication.DosageQuantityStock,
            medication.NeedRecipe
        );
    }

    public async Task<MedicationResponse> CreatedAsync(CreateMedicationRequest request)
    {
        if (await _context.Medications.AnyAsync(m => m.Name == request.Name && m.Dosage == request.Dosage))
        {
            throw new InvalidOperationException($"Já existe um medicamento cadastrado com o nome '{request.Name}'.");
        }

        
        var medication = new Medication
        {
            Name = request.Name,
            Dosage = request.Dosage,
            Classification = request.Classification,
            Price = request.Price,
            DosageQuantityStock = request.DosageQuantityStock,
            NeedRecipe = request.NeedRecipe
        };

        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();

        return new MedicationResponse(
            medication.Id,
            medication.Name,
            medication.Dosage,
            medication.Classification,
            medication.Price,
            medication.DosageQuantityStock,
            medication.NeedRecipe
        );
    }

    public async Task<bool> UpdateStockAsync(int id, int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("A quantidade de estoque não pode ser negativa.");
        }

        var medication = await _context.Medications.FindAsync(id);

        if (medication == null)
        {
            return false;
        }

        medication.DosageQuantityStock = quantity;

        await _context.SaveChangesAsync();

        return true;
    }
}