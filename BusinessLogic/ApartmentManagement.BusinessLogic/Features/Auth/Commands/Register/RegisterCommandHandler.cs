using ApartmentManagement.Core.Utils;
using ApartmentManagement.DataAccessLayer.Abstract;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest,RegisterResponseModel>
{
    public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
    {
    }

    public async Task<RegisterResponseModel> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        UnitOfWork.OpenTransaction();
/*
        var passwordSalt = PasswordManager.GenerateSalt();
        var passwordHash = PasswordManager.HashPassword(request.Password, passwordSalt);

        var user = new Entities.Model.User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = Convert.ToBase64String(passwordSalt),
            IsConfirmed = isConfirmed
        };*/
        throw new BusinessRuleException(new List<string>() { BusinessRuleExceptionKey.GENERAL });
    }
}