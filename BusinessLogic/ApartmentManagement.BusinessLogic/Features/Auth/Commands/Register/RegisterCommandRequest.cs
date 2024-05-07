using MediatR;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RegisterCommandRequest : IRequest<RegisterResponseModel>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Email { get; set; }
    public string EmailConfirm { get; set; }
}