using Microsoft.EntityFrameworkCore;
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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
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

app.UseAuthorization();

app.MapControllers();

app.Run();