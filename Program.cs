    using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TraineeAPI.Data;
using TraineeAPI.Repositories;
using TraineeAPI.Services;
using TraineeAPI.Services.@interface;
using TraineeAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// =====================================================
// Controllers
// =====================================================

builder.Services.AddControllers();


// =====================================================
// Swagger / OpenAPI
// =====================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


// =====================================================
// CORS
// =====================================================

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


// =====================================================
// Database
// =====================================================

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found."
    );

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// =====================================================
// Repositories
// =====================================================

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IStudentRepository,
                           StudentRepository>();

builder.Services.AddScoped<ITeacherRepository,
                           TeacherRepository>();

builder.Services.AddScoped<IModuleRepository,
                           ModuleRepository>();



// =====================================================
// Services
// =====================================================

builder.Services.AddScoped<ICourseService,
                           CourseService>();

builder.Services.AddScoped<IStudentService,
                           StudentService>();

builder.Services.AddScoped<ITeacherService,
                           TeacherService>();

builder.Services.AddScoped<IModuleService,
                           ModuleService>();




// =====================================================
// Authentication Service
// =====================================================

builder.Services.AddScoped<IAuthService, AuthService>();


// =====================================================
// JWT Authentication
// =====================================================

var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
    ?? throw new InvalidOperationException("JWT Issuer is missing.");

var jwtAudience = builder.Configuration["Jwt:Audience"]
    ?? throw new InvalidOperationException("JWT Audience is missing.");

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,

        ValidateAudience = true,
        ValidAudience = jwtAudience,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey)
        ),

        ClockSkew = TimeSpan.Zero
    };
});


// =====================================================
// Authorization
// =====================================================

builder.Services.AddAuthorization();


// =====================================================
// Build Application
// =====================================================

var app = builder.Build();


// =====================================================
// Swagger
// =====================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "TraineeAPI V1"
        );
    });
}


// =====================================================
// Middleware
// =====================================================

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();

app.UseAuthorization();


// =====================================================
// Controllers
// =====================================================

app.MapControllers();


// =====================================================
// Run
// =====================================================

app.Run();