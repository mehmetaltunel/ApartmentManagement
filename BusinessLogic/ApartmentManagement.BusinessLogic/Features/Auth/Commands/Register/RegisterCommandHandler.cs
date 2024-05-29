using ApartmentManagement.Core.ResponseManager;
using ApartmentManagement.Core.Utils;
using ApartmentManagement.DataAccessLayer.Abstract;
using ApartmentManagement.DataAccessLayer.Abstract.Repositoreis;
using ApartmentManagement.Entities.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequestModel,BaseResponseModel<RegisterCommandResponseModel>>
{
    public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
    {
    }

    public async Task<BaseResponseModel<RegisterCommandResponseModel>> Handle(RegisterCommandRequestModel requestModel, CancellationToken cancellationToken)
    {
        var userNameCheck = await UnitOfWork.Repository<IUserRepository>().Query()
            .FirstOrDefaultAsync(x => x.Username == requestModel.Username);
        if(userNameCheck is not null)
            throw new BusinessRuleException(new List<string>()  { "Kullanıcı adı mevcut, farklı bir kullanıcı ile deneyiniz." });
        UnitOfWork.OpenTransaction();
        var passwordSalt = PasswordManager.GenerateSalt();
        var passwordHash = PasswordManager.HashPassword(requestModel.Password, passwordSalt);

        var user = new User
        {
            Username = requestModel.Username,
            Email = requestModel.Email,
            PasswordHash = passwordHash,
            PasswordSalt = Convert.ToBase64String(passwordSalt),
            IsConfirmed = true
        };

        UnitOfWork.Repository<IUserRepository>().Add(user);
        await UnitOfWork.SaveChangesAsync();

        UnitOfWork.Commit();
        return ResponseManager.Ok(new RegisterCommandResponseModel());
    }
}