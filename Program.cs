using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TraineeAPI.Data;
using TraineeAPI.Repositories;
using TraineeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

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

// ADD THESE BEFORE Build()

builder.Services.AddDbContext<TraineeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IStudentRepository,
                           StudentRepository>();

builder.Services.AddScoped<IStudentService,
                           StudentService>();

builder.Services.AddScoped<ITeacherRepository,
                           TeacherRepository>();

builder.Services.AddScoped<ITeacherService,
                           TeacherService>();

builder.Services.AddScoped<IModuleRepository,
                           ModuleRepository>();

builder.Services.AddScoped<IModuleService,
                           ModuleService>();

builder.Services.AddScoped<IAssignmentRepository,
                           AssignmentRepository>();

builder.Services.AddScoped<IAssignmentService,
                           AssignmentService>();

builder.Services.AddScoped<IUserDetailsRepository,
                           UserDetailsRepository>();

builder.Services.AddScoped<IUserDetailsService,
                           UserDetailsService>();

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!))
            };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "My API V1");
    });
}
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();   

app.UseAuthorization();

app.MapControllers();

app.Run();