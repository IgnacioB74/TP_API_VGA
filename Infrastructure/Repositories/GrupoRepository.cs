using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class GrupoRepository : RepositoryBase<GrupoMuscular>,
          IGrupoRepository
    {
        public GrupoRepository(AppDbContext context) : base(context)
        {
        }
    }
}