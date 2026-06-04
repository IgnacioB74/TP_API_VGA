using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using GymAPI.Services;

namespace Presentation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEjercicioService, EjercicioService>();
        services.AddScoped<IGrupoService, GrupoService>();
        services.AddScoped<IRutinaService, RutinaService>();
        services.AddScoped<IPagoService, PagoService>();
        services.AddScoped<IDietaService, DietaService>();
        services.AddScoped<IPlanService, PlanService>();
        services.AddScoped<IEjercicioRepository, EjercicioRepository>();
        services.AddScoped<IEjercicioService, EjercicioService>();
        services.AddScoped<IGrupoRepository, GrupoRepository>();
        services.AddScoped<IGrupoService, GrupoService>();

        //SON LOS ADDSCOPED DEL PROGRAM.cs
        return services;
    }
}