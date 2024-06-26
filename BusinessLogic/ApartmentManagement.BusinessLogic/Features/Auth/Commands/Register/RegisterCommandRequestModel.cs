using ApartmentManagement.Core.ResponseManager;
using MediatR;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RegisterCommandRequestModel : IRequest<BaseResponseModel<RegisterCommandResponseModel>>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Email { get; set; }
    public string EmailConfirm { get; set; }
}