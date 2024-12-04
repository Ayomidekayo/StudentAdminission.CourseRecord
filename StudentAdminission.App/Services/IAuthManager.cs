using Microsoft.AspNetCore.Identity;
using StudentAdminission.App.DTOs.Authentication;

namespace StudentAdminission.App.Services
{
    public interface IAuthManager
    {
        Task<AuthReponseDto> Login(LogInDto dto);
        Task<IEnumerable<IdentityError>> Registration(RegistrationDto registrationDto);
    }
}
