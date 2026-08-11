using MedicationManager.DTO;
using MedicationManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManager.Controller;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet("GetDoctors")]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAll()
    {
        var doctor = await _doctorService.GetAllDoctorsAsync();
        
        return Ok(doctor);
    }
    
    [HttpGet("obter/{id:int}")]
    public async Task<ActionResult<DoctorDTO>> GetById(int id)
    {
        var doctor = await _doctorService.GetByIdAsync(id);

        if (doctor == null)
        {
            return NotFound(new { message = $"Médico com o ID {id} não foi encontrado." });
        }

        return Ok(doctor);
    }
    
    [HttpPost("cadastrar")]
    public async Task<ActionResult<DoctorDTO>> Create([FromBody] DoctorDTO dto)
    {
        try
        {
            var createdDoctor = await _doctorService.CreatedAsync(dto);

            return Ok(createdDoctor);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("atualizar/{id:int}")]
    public async Task<ActionResult<DoctorDTO>> Update(int id,[FromBody] DoctorDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest(new { message = "O ID informado na URL não coincide com o ID do corpo da requisição." });
        }
        try
        {
            var updateDoctor = await _doctorService.UpdatedAsync(dto);

            return Ok(updateDoctor);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("remover/{id:int}")]
    public async Task<ActionResult<DoctorDTO>> Delete(int id)
    {
        try
        {
            var  deleteDoctor = await _doctorService.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}