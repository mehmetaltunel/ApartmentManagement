using ApartmentManagement.Core.ResponseManager;
using ApartmentManagement.Core.Utils;
using ApartmentManagement.DataAccessLayer.Abstract;
using ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;
using ApartmentManagement.Entities.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest,BaseResponseModel<RegisterResponseModel>>
{
    public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
    {
    }

    public async Task<BaseResponseModel<RegisterResponseModel>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        UnitOfWork.OpenTransaction();

        var passwordSalt = PasswordManager.GenerateSalt();
        var passwordHash = PasswordManager.HashPassword(request.Password, passwordSalt);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = Convert.ToBase64String(passwordSalt),
            IsConfirmed = true
        };

        UnitOfWork.Repository<IUserRepository>().Add(user);
        await UnitOfWork.SaveChangesAsync();

        UnitOfWork.Commit();
        return ResponseManager.Ok(new RegisterResponseModel());
    }
}