using Api.DataTransferObjects.v1;

namespace Api.Interfaces.v1;

public interface IUserRepository
{
    User GetRoles(string username, string password);
}