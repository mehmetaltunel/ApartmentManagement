namespace ApartmentManagement.Entities.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string Email { get; set; }
    public bool IsConfirmed { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public string ResetPasswordToken { get; set; }
    public DateTime? ResetPasswordTokenExpireDate { get; set; }
    public string ProviderType { get; set; }
}