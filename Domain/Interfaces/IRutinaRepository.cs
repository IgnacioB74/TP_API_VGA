using Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRutinaRepository : IRepositoryBase<Rutina>
    {
        Task<RutinaUsuario> AddRutinaUsuarioAsync(RutinaUsuario rutinaUsuario);
        Task<bool> ExistsRutinaUsuarioAsync(int id);

        Task<RutinaDetalle> AddRutinaDetalleAsync(RutinaDetalle detalle);
        Task<RutinaUsuario?> GetRutinaUsuarioAsync(int id);

        Task<List<RutinaDetalle>> GetDetallesRutinaAsync(int rutinaUsuarioId);
    }
}
