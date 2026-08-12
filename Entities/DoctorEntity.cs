namespace MedicationManager.Entities;

public class DoctorEntity
{
        public int Id { get; set; }
        
        public required string Name { get; set; }
        
        public required string Email { get; set; }
        
        public required string Crm { get; set; }
        
        public int UserId { get; set; }
}