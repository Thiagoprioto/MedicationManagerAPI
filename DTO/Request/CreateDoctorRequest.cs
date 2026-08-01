namespace MedicationManager.DTO;

public record CreateDoctorRequest
(
    string Name,
    
    string Email,
    
    string Crm
);