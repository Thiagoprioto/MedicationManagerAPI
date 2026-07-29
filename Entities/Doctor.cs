namespace MedicationManager.Entities;

public class Doctor
{
        public int Id { get; set; }
        
        public required string Name { get; set; }
        
        public required string Email { get; set; }
        
        public required string Crm { get; set; }
}