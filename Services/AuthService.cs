using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly PasswordHasher<UserDetails> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserDetailsRepository userDetailsRepository,
            IConfiguration configuration)
        {
            _userDetailsRepository = userDetailsRepository;
            _passwordHasher = new PasswordHasher<UserDetails>();
            _configuration = configuration;
        }

        public async Task<ApiResponse<RegisterResponseViewModel>> RegisterAsync(
            RegisterRequestViewModel request)
        {
            var existingUser = await _userDetailsRepository
                .GetByUsernameAsync(request.Username);

            if (existingUser != null)
            {
                return new ApiResponse<RegisterResponseViewModel>
                {
                    Success = false,
                    Message = "Username already exists",
                    Data = null
                };
            }

            var user = new UserDetails
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                request.Password);

            var createdUser = await _userDetailsRepository.AddAsync(user);

            var response = new RegisterResponseViewModel
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return new ApiResponse<RegisterResponseViewModel>
            {
                Success = true,
                Message = "Registration successful",
                Data = response
            };
        }

        public async Task<ApiResponse<LoginResponseViewModel>> LoginAsync(
            LoginRequestViewModel request)
        {
            var user = await _userDetailsRepository
                .GetByUsernameAsync(request.Username);

            if (user == null)
            {
                return new ApiResponse<LoginResponseViewModel>
                {
                    Success = false,
                    Message = "Invalid username or password",
                    Data = null
                };
            }

            var passwordResult = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (passwordResult == PasswordVerificationResult.Failed)
            {
                return new ApiResponse<LoginResponseViewModel>
                {
                    Success = false,
                    Message = "Invalid username or password",
                    Data = null
                };
            }

            // JWT token will be created here
            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Name,user.Username)
            };

            var key = new SymmetricSecurityKey(
     Encoding.UTF8.GetBytes(
         _configuration["Jwt:Key"]!
     )
 );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(_configuration["Jwt:ExpireMinutes"]!)
                ),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return new ApiResponse<LoginResponseViewModel>
            {
                Success = true,
                Message = "Login successful",
                Data = new LoginResponseViewModel
                {
                    Token = tokenString
                }
            };

            throw new NotImplementedException();
        }
    }
}