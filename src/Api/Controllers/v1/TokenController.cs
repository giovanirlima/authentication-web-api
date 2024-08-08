using Api.DataTransferObjects.v1;
using Api.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Route("api/authentications")]
public class TokenController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public TokenController(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    [HttpPost]
    public Task<ActionResult<dynamic>> GenerateToken(User request)
    {
        var user = _userRepository.GetRoles(request.Username, request.Password);

        if (user is null)
            return Task.FromResult<ActionResult<dynamic>>(NotFound(new { Notification = "Usuário ou senha inválidos." }));

        var token = _tokenService.GenerateToken(user);

        var result = new
        {
            User = user.Username,
            Token = token
        };

        return Task.FromResult<ActionResult<dynamic>>(Ok(result));
    }
}