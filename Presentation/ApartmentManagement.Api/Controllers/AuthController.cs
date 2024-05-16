using ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Api.Controllers;

[Route("api/[controller]"), ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request)
        => Ok(await _mediator.Send(request));
}