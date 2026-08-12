using MedicationManager.Entities;

namespace MedicationManager.Service.Interfaces.IAuth;

public interface ITokenService
{
    string GenerateToken(UserEntity userEntity);
}