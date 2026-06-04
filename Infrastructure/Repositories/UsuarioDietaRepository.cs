using Domain.Entities;
using GymAPI.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioDietaRepository
        : RepositoryBase<UsuarioDieta>,
          IUsuarioDietaRepository
    {
        public UsuarioDietaRepository(
            AppDbContext context)
            : base(context)
        {
        }
    }
}