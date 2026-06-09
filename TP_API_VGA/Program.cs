using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using GymAPI.Repositories;
using GymAPI.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Extensions;
using Presentation.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==============================
// BASE DE DATOS
// ==============================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ==============================
// REPOSITORIOS
// ==============================
builder.Services.AddScoped<IDietaRepository, DietaRepository>();
builder.Services.AddScoped<IEjercicioRepository, EjercicioRepository>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IRutinaRepository, RutinaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioDietaRepository, UsuarioDietaRepository>();
builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
builder.Services.AddScoped<IDietaRepository, DietaRepository>();
builder.Services.AddScoped<IUsuarioDietaRepository, UsuarioDietaRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();

// ==============================
// SERVICIOS
// ==============================
builder.Services.AddApplicationServices();
// builder.Services.AddInfrastructureServices();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDietaService, DietaService>();
builder.Services.AddScoped<IEjercicioService, EjercicioService>();
builder.Services.AddScoped<IGrupoService, GrupoService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IRutinaService, RutinaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAlimentoService, AlimentoService>();
builder.Services.AddScoped<IPagoService, PagoService>();

// ==============================
// MIDDLEWARE
// ==============================
builder.Services.AddScoped<CustomExceptionHandlingMiddleware>();

// ==============================
// JWT
// ==============================
var jwtKey =
    builder.Configuration["Key"]
    ?? builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new Exception("Key no configurada.");
}

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});

// ==============================
// SWAGGER
// ==============================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gym API",
        Version = "v1",
        Description = "API para gesti�n de gimnasio"
    });

    setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT. Ejemplo: Bearer eyJhbGciOiJIUzI1NiIs..."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ==============================
// CORS
// ==============================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ==============================
// SERVICIO EXTERNO DE CHISTES
// ==============================
builder.Services.AddHttpClient<IJokeService, JokeApiClient>(client =>
{
    client.BaseAddress =
        new Uri("https://official-joke-api.appspot.com/");
    client.DefaultRequestHeaders.Add(
        "Accept", "application/json");
});

// ==============================
// CONTROLADORES
// ==============================
builder.Services.AddControllers();

// ==============================
// BUILD APP
// ==============================

var app = builder.Build();

// ==============================
// SWAGGER (SIEMPRE HABILITADO)
// ==============================
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gym API v1");

    // Swagger disponible directamente en:
    // https://localhost:7161/
    // Si prefieres usar /swagger, elimina la l�nea siguiente.
    options.RoutePrefix = string.Empty;
});

// Middleware global de excepciones
app.UseMiddleware<CustomExceptionHandlingMiddleware>();

// HTTPS
app.UseHttpsRedirection();

// CORS
app.UseCors("AllowAll");

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

// Run
app.Run();