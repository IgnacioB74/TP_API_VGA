using Application.DTOs.RutinasDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class RutinaService : IRutinaService
{
    private readonly IRutinaRepository _repository;

    public RutinaService(IRutinaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Rutina>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Rutina> GetByIdAsync(int id)
    {
        var rutina = await _repository.GetByIdAsync(id);

        if (rutina == null)
            throw new Exception("Rutina no encontrada");

        return rutina;
    }

    public async Task<int> CreateAsync(RutinaCreateDTO dto)
    {
        var rutina = new Rutina
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Intensidad = dto.Intensidad,
            Activa = dto.Activa,
            EjerciciosXDia = dto.EjerciciosXDia
        };

        await _repository.AddAsync(rutina);

        await _repository.SaveChangesAsync();

        return rutina.ID_Rutina;
    }

    public async Task UpdateAsync(int id, RutinaUpdateDTO dto)
    {
        var rutina = await _repository.GetByIdAsync(id);

        if (rutina == null)
            throw new Exception("Rutina no encontrada");

        rutina.Nombre = dto.Nombre;
        rutina.Descripcion = dto.Descripcion;
        rutina.Intensidad = dto.Intensidad;
        rutina.Activa = dto.Activa;
        rutina.EjerciciosXDia = dto.EjerciciosXDia;

        _repository.Update(rutina);

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var rutina = await _repository.GetByIdAsync(id);

        if (rutina == null)
            throw new Exception("Rutina no encontrada");

        _repository.Remove(rutina);

        await _repository.SaveChangesAsync();
    }

    public async Task<int> AsignarRutinaAsync(AsignarRutinaDTO dto)
    {
        var asignacion = new RutinaUsuario
        {
            Mail = dto.Mail,
            Nombre = dto.Nombre,
            Fecha = DateTime.Now
        };

        await _repository.AddRutinaUsuarioAsync(asignacion);

        return asignacion.ID;
    }

    public async Task AddEjercicioAsync(
        RutinaDetalleCreateDTO dto)
    {
        var detalle = new RutinaDetalle
        {
            ID_RutinaUsuario = dto.ID_RutinaUsuario,
            Dia = dto.Dia,
            ID_Ejercicio = dto.ID_Ejercicio
        };

        await _repository.AddRutinaDetalleAsync(detalle);
    }
}