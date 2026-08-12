using MedicationManager.DTO;
using MedicationManager.Entities;

namespace MedicationManager.Mapper;

public static class DoctorMapper
{
    public static DoctorEntity FromDTO(DoctorDTO dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Crm = dto.Crm,
        Email = dto.Email,
        UserId = dto.UserId
    };

    public static DoctorDTO ToDTO(this DoctorEntity entity) => new(
        entity.Id,
        entity.Name,
        entity.Email,
        entity.Crm,
        entity.UserId
    );

    public static void UpdateFromDTO(this DoctorEntity entity, DoctorDTO dto)
    {
        entity.Name = dto.Name;
        entity.Email = dto.Email;
        entity.Crm = dto.Crm;
        entity.UserId = dto.UserId;
    }
}