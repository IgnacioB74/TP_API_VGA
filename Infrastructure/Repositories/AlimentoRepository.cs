using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class AlimentoRepository : RepositoryBase<Alimento>,
          IAlimentoRepository
    {
        public AlimentoRepository(AppDbContext context) : base(context)
        {
        }
    }
}