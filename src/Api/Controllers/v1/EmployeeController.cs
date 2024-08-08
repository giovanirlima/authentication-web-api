using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Route("api/authentications")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    [Route("Anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Authorize]
    [Route("Authenticated")]
    public string Authenticated() => $"Autenticado - {User.Identity.Name}";

    [HttpGet]
    [Route("Employee")]
    [Authorize(Roles = "Employee, Manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("Manager")]
    [Authorize(Roles = "Manager")]
    public string Manager() => "Gerente";
}