using MedicationManager.Context;
using MedicationManager.Exception;
using MedicationManager.Service;
using MedicationManager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MedicationManagerOnlineDB");

builder.Services.AddDbContext<MedicationManagerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IMedicationService, MedicationService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapControllers();

app.Run();