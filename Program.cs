using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TraineeAPI.Repositories;
using TraineeAPI.Services;
using TraineeMVC.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext")
    ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(); //JWT

builder.Services.AddScoped<IJWTService, JWTService>(); //JWT

//===============================================================
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
builder.Services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();

builder.Services.AddScoped<ICourseBusiness, CourseBusiness>();
builder.Services.AddScoped<IStudentBusiness, StudentBusiness>();
builder.Services.AddScoped<ITeacherBusiness, TeacherBusiness>();
builder.Services.AddScoped<IUserDetailsBusiness, UserDetailsBusiness>();
//===============================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

//=========================JWT Token Configuration=========================
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
            )
        };
});
//===============================================================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

//=========================JWT Middleware=========================
app.UseAuthentication();
app.UseAuthorization();
//===============================================================

app.MapControllers();

app.Run();