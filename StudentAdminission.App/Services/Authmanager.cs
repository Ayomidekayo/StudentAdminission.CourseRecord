using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentAdminission.App.DTOs.Authentication;
using StudentAdmission.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentAdminission.App.Services
{
    public class Authmanager : IAuthManager
    {
        private readonly UserManager<SchoolUser> _userManager;
        private readonly IConfiguration _configuration;
        private SchoolUser? _user;
        public Authmanager(UserManager<SchoolUser> userManager,IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthReponseDto> Login(LogInDto dto)
        {
            _user=await _userManager.FindByEmailAsync(dto.EmailAdress);
            if (_user is null)
                return default;
             bool isCredentialValid=await _userManager.CheckPasswordAsync(_user,dto.Password);
            if (!isCredentialValid)
                return default;

            var token = await GenerateTokenAsync();
            return new AuthReponseDto
            {
                UserId = _user.Id,
                Token = token,
            };
        }

        public async Task<IEnumerable<IdentityError>> Registration(RegistrationDto registrationDto)
        {
            _user = new SchoolUser
            {
                Email = registrationDto.EmailAdress,
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                UserName = registrationDto.EmailAdress,
                DateOfBirth = registrationDto.DateOfbirth,
            };
            var result = await _userManager.CreateAsync(_user, registrationDto.Password);
            if (result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(_user, "User");
            }
           return result.Errors;
        }

        private async Task<string> GenerateTokenAsync()
        {
            var secrity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSetting:Key"]));
            var credentials = new SigningCredentials(secrity, SecurityAlgorithms.HmacSha256);

            var role = await _userManager.GetRolesAsync(_user);
            var roleclams = role.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
            var userClams=await _userManager.GetClaimsAsync(_user);


            var clams=new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,_user.Email),
                new Claim("UaseId",_user.Id)
            }.Union(roleclams).Union(userClams);

            var token = new JwtSecurityToken
                (
                issuer: _configuration["JWTSetting:Issuer"],
                audience: _configuration["JWTSetting:Audience"],
                claims: clams,
                expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JWTSetting:DurationInHours"])),
               signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
