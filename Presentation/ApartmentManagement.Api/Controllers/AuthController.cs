using ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request)
        => Ok(await _mediator.Send(request));
}