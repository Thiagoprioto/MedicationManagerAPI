using MedicationManager.DTO;
using MedicationManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManager.Controller;

[ApiController]
[Route("api/[controller]")] // Rota base: api/doctors (ou api/doctor)
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAll()
    {
        var doctors = await _doctorService.GetAllDoctorsAsync();
        return Ok(doctors);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<DoctorDTO>> GetById(int id)
    {
        var doctor = await _doctorService.GetByIdAsync(id);

        if (doctor == null)
        {
            return NotFound(new { message = $"Médico com o ID {id} não foi encontrado." });
        }

        return Ok(doctor);
    }
    
    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> Create([FromBody] DoctorDTO dto)
    {
        try
        {
            var createdDoctor = await _doctorService.CreatedAsync(dto);
            
            return CreatedAtAction(nameof(GetById), new { id = createdDoctor.Id }, createdDoctor);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<DoctorDTO>> Update(int id, [FromBody] DoctorDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest(new { message = "O ID informado na URL não coincide com o ID do corpo da requisição." });
        }

        try
        {
            var updatedDoctor = await _doctorService.UpdatedAsync(dto);
            return Ok(updatedDoctor);
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
            await _doctorService.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}