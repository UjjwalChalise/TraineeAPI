using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Services.Interfaces;
using TraineeAPI.ViewModels;

namespace TraineeAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<UserDetails> _passwordHasher;

        public AuthService(
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            _passwordHasher = new PasswordHasher<UserDetails>();
        }


        // =========================
        // REGISTER
        // =========================
        public async Task<string> RegisterAsync(
            RegisterViewModel model)
        {
            // Check if email already exists
            var existingUser = await _context.UserDetails
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }


            // Create user
            var user = new UserDetails
            {
                FullName = model.FullName,
                Email = model.Email,
                Role = model.Role,
                CreatedAt = DateTime.UtcNow
            };


            // Hash password
            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                model.Password
            );


            // Add user to database
            _context.UserDetails.Add(user);

            await _context.SaveChangesAsync();


            return "User registered successfully.";
        }


        // =========================
        // LOGIN
        // =========================
        public async Task<string?> LoginAsync(
            LoginViewModel model)
        {
            // Find user using email
            var user = await _context.UserDetails
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                return null;
            }


            // Verify password
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                model.Password
            );


            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }


            // Generate JWT
            var token = GenerateJwtToken(user);

            return token;
        }


        // =========================
        // GENERATE JWT
        // =========================
        private string GenerateJwtToken(UserDetails user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");


            var key = jwtSettings["Key"];

            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("JWT Key is missing.");
            }


            var issuer = jwtSettings["Issuer"];

            var audience = jwtSettings["Audience"];

            var expiryMinutes = int.Parse(
                jwtSettings["ExpiryMinutes"] ?? "60"
            );


            // Claims
            var claims = new List<Claim>
            {
                new Claim(
                    JwtRegisteredClaimNames.Sub,
                    user.Id.ToString()
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.FullName
                ),

                new Claim(
                    ClaimTypes.Email,
                    user.Email
                ),

                new Claim(
                    ClaimTypes.Role,
                    user.Role
                )
            };


            // Security key
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)
            );


            // Signing credentials
            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );


            // Create token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    expiryMinutes
                ),
                signingCredentials: credentials
            );


            // Convert token to string
            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}