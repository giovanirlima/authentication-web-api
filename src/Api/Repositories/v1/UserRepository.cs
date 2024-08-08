using Api.DataTransferObjects.v1;
using Api.Interfaces.v1;

namespace Api.Repositories.v1;

public class UserRepository : IUserRepository
{
    public User GetRoles(string username, string password) =>
        DataExample().FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);

    private static IEnumerable<User> DataExample() =>
        [
            new (1, "Batman", "Batman", "Manager"),
            new (2, "Robin", "Robin", "Employee")
        ];
}