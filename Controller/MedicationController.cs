using MedicationManager.DTO;
using MedicationManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManager.Controller;

[ApiController]
[Route("api/[controller]")] // Rota base: api/medication
public class MedicationController : ControllerBase
{
    private readonly IMedicationService _medicationService;

    public MedicationController(IMedicationService medicationService)
    {
        _medicationService = medicationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicationDTO>>> GetAll()
    {
        var medications = await _medicationService.GetAllMedicationAsync();
        return Ok(medications);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> GetById(int id)
    {
        var medication = await _medicationService.GetByIdAsync(id);

        if (medication == null)
        {
            return NotFound(new { message = $"Medicamento com o ID {id} não foi encontrado." });
        }

        return Ok(medication);
    }
    
    [HttpPost]
    public async Task<ActionResult<MedicationDTO>> Create([FromBody] MedicationDTO dto)
    {
        try
        {
            var createdMedication = await _medicationService.CreatedAsync(dto);
            
            return CreatedAtAction(nameof(GetById), new { id = createdMedication.Id }, createdMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> Update(int id, [FromBody] MedicationDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest(new { message = "O ID informado na URL não coincide com o ID do corpo da requisição." });
        }

        try
        {
            var updatedMedication = await _medicationService.UpdatedAsync(dto);
            return Ok(updatedMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _medicationService.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}