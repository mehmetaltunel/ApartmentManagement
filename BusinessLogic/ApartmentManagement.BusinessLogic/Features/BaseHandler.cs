using System.Security.Claims;
using ApartmentManagement.DataAccessLayer.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.BusinessLogic.Features;

public class BaseHandler
{
    protected readonly IUnitOfWork UnitOfWork;
    protected IMapper Mapper;
    private IHttpContextAccessor _httpContextAccessor;

    public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    
    protected long? UserId
    {
        get
        {
            var val = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return val is null ? null : Convert.ToInt32(val);
        }
    }
}