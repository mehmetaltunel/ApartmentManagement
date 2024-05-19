using FluentValidation;

namespace ApartmentManagement.BusinessLogic.Features.Auth.Commands.Register;

public class RequestModelValidatior : AbstractValidator<RegisterCommandRequestModel>
{
    public RequestModelValidatior()
    {
        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
            .Length(3, 50).WithMessage("Kullanıcı adı en az 3, en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-Z].*").WithMessage("Kullanıcı adı bir harfle başlamalıdır.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .Length(6, 100).WithMessage("Şifre en az 6, en fazla 100 karakter olabilir.");

        RuleFor(user => user.PasswordConfirm)
            .Equal(user => user.Password).WithMessage("Şifreler uyuşmalıdır.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email formatında olmalıdır.");

        RuleFor(user => user.EmailConfirm)
            .Equal(user => user.Email).WithMessage("Email adresleri uyuşmalıdır.");
    }
}
