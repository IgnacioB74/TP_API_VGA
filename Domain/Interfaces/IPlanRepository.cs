using Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlanRepository : IRepositoryBase<PlanEntrenamiento>
    {
        Task<List<PlanEntrenamiento>> GetPlanesActivosAsync();
    }
}
