namespace MedicationManager.DTO.Response;

public record DoctorResponse
(
    int Id, 
    string Name, 
    string Email, 
    string Crm
);