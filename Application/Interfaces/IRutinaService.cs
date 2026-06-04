using Application.DTOs.RutinasDTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface IRutinaService
{
    Task<List<Rutina>> GetAllAsync();

    Task<Rutina> GetByIdAsync(int id);

    Task<int> CreateAsync(RutinaCreateDTO dto);

    Task UpdateAsync(int id, RutinaUpdateDTO dto);

    Task DeleteAsync(int id);

    Task<int> AsignarRutinaAsync(AsignarRutinaDTO dto);

    Task AddEjercicioAsync(RutinaDetalleCreateDTO dto);
}