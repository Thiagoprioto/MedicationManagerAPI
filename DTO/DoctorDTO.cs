namespace MedicationManager.DTO;

public record DoctorDTO
(
    int Id, 
    string Name, 
    string Email, 
    string Crm,
    int UserId
);