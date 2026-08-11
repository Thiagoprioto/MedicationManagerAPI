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
    
    [HttpGet("GetMedications")]
    public async Task<ActionResult<IEnumerable<MedicationDTO>>> GetAll()
    {
        var medications = await _medicationService.GetAllMedicationAsync();
        
        return Ok(medications);
    }
    
    [HttpGet("obter/{id:int}")]
    public async Task<ActionResult<MedicationDTO>> GetById(int id)
    {
        var medications = await _medicationService.GetByIdAsync(id);

        if (medications == null)
        {
            return NotFound(new { message = $"Medicamento com o ID {id} não foi encontrado." });
        }

        return Ok(medications);
    }
    
    [HttpPost("cadastrar")]
    public async Task<ActionResult<MedicationDTO>> Create([FromBody] MedicationDTO dto)
    {
        try
        {
            var createdMedication = await _medicationService.CreatedAsync(dto);

            return Ok(createdMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("atualizar/{id:int}")]
    public async Task<ActionResult<MedicationDTO>> Update(int id,[FromBody] MedicationDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest(new { message = "O ID informado na URL não coincide com o ID do corpo da requisição." });
        }
        try
        {
            var updateMedication = await _medicationService.UpdatedAsync(dto);

            return Ok(updateMedication);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("remover/{id:int}")]
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