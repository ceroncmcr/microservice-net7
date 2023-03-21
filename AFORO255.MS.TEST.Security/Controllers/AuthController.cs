using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.DTOs;
using AFORO255.MS.TEST.Security.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AFORO255.MS.TEST.Security.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccessService _accessService;
    private readonly JwtOptions _jwtOptions;

    public AuthController(IAccessService accessService, IOptionsSnapshot<JwtOptions> jwtOptions)
    {
        _accessService = accessService;
        _jwtOptions = jwtOptions.Value;
    }

    [HttpGet]
    public IActionResult Get() 
    {
        return Ok(_accessService.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] AuthRequest req)
    {
        if (!_accessService.Validate(req.UserName, req.Password))
        {
            return Unauthorized();
        }

        string token = JwtToken.Create(_jwtOptions);
        Response.Headers.Add("access-control-expose-headers", "Authorization");
        Response.Headers.Add("Authorization", token);
        return Ok(new AuthResponse(token, "5h"));
    }
}
