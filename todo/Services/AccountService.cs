using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todo.Models;
using Todo.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataAccessContext _context;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper, DataAccessContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserResponse> SignUpAsync(SignUpRequestDTO input)
        {  
            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                UserName = input.Email
            };
            await _userManager.CreateAsync(user, input.Password);
            return _mapper.Map<UserResponse>(input);
        }
        public async Task<string> SignInAsync(SignInRequestDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])
            };

            var authenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
