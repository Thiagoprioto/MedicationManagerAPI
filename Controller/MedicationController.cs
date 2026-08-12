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
            return NotFound(new { message = $"Medicamento com o ID {id} não foi encontrado." });

        return Ok(medication);
    }

    [HttpPost]
    public async Task<ActionResult<MedicationDTO>> Create([FromBody] MedicationDTO dto)
    {
        var createdMedication = await _medicationService.CreatedAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdMedication.Id }, createdMedication);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MedicationDTO>> Update(int id, [FromBody] MedicationDTO dto)
    {
        if (id != dto.Id)
            return BadRequest(new { message = "O ID da URL não coincide com o ID informado no corpo da requisição." });

        var updatedMedication = await _medicationService.UpdatedAsync(dto);
        return Ok(updatedMedication);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _medicationService.DeleteAsync(id);
        return NoContent();
    }
}