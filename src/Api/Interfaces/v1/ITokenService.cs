using Api.DataTransferObjects.v1;

namespace Api.Interfaces.v1;

public interface ITokenService
{
    string GenerateToken(User user);
}