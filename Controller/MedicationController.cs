using MedicationManager.DTO;
using MedicationManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManager.Controller;


[ApiController]
[Route("api/[controller]")]
public class MedicationController : ControllerBase
{
    private readonly IMedicationService _medicationService;

    public MedicationController(IMedicationService medicationService)
    {
        _medicationService = medicationService;
    }

    // GET: api/medication
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicationDTO>>> GetAll()
    {
        var medications = await _medicationService.GetAllMedicationAsync();
        
        // Retorna HTTP 200 OK com a lista (mesmo que seja vazia [])
        return Ok(medications);
    }

    // GET: api/medication/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> GetById(int id)
    {
        var medications = await _medicationService.GetByIdAsync(id);

        if (medications == null)
        {
            return NotFound(new { message = $"Medicamento com o ID {id} não foi encontrado." });
        }

        return Ok(medications);
    }

    // POST: api/medication
    [HttpPost]
    public async Task<ActionResult<MedicationDTO>> Create([FromBody] MedicationDTO dto)
    {
        try
        {
            var createdMedication = await _medicationService.CreateAsync(dto);

            return Ok(createdMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> Update([FromBody] MedicationDTO dto)
    {
        try
        {
            var updateMedication = await _medicationService.UpdateAsync(dto);

            return Ok(updateMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> Delete(int id)
    {
        try
        {
            var  deleteMedication = await _medicationService.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}