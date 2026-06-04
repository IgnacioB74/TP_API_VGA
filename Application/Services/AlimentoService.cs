using Application.DTOs.AlimentosDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AlimentoService : IAlimentoService
    {
        private readonly IAlimentoRepository _repository;

        public AlimentoService(
            IAlimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AlimentoResponseDTO>> GetAllAsync()
        {
            var alimentos =
                await _repository.GetAllAsync();

            return alimentos.Select(a =>
                new AlimentoResponseDTO
                {
                    ID_Alimento = a.ID_Alimento,
                    Nombre = a.Nombre,
                    Calorias = a.Calorias,
                    Proteinas = a.Proteinas,
                    Carbohidratos = a.Carbohidratos,
                    Grasas = a.Grasas,
                    Descripcion = a.Descripcion,
                    ID_Categoria = a.ID_Categoria,
                    ID_Objetivo = a.ID_Objetivo
                })
                .ToList();
        }

        public async Task<AlimentoResponseDTO>
            GetByIdAsync(int id)
        {
            var alimento =
                await _repository.GetByIdAsync(id);

            if (alimento == null)
                throw new Exception("Alimento no encontrado");

            return new AlimentoResponseDTO
            {
                ID_Alimento = alimento.ID_Alimento,
                Nombre = alimento.Nombre,
                Calorias = alimento.Calorias,
                Proteinas = alimento.Proteinas,
                Carbohidratos = alimento.Carbohidratos,
                Grasas = alimento.Grasas,
                Descripcion = alimento.Descripcion,
                ID_Categoria = alimento.ID_Categoria,
                ID_Objetivo = alimento.ID_Objetivo
            };
        }

        public async Task<int>
            CreateAsync(AlimentoCreateDTO dto)
        {
            var alimento = new Alimento
            {
                Nombre = dto.Nombre,
                Calorias = dto.Calorias,
                Proteinas = dto.Proteinas,
                Carbohidratos = dto.Carbohidratos,
                Grasas = dto.Grasas,
                Descripcion = dto.Descripcion,
                ID_Categoria = dto.ID_Categoria,
                ID_Objetivo = dto.ID_Objetivo
            };

            await _repository.AddAsync(alimento);

            await _repository.SaveChangesAsync();

            return alimento.ID_Alimento;
        }

        public async Task UpdateAsync(
            int id,
            AlimentoUpdateDTO dto)
        {
            var alimento =
                await _repository.GetByIdAsync(id);

            if (alimento == null)
                throw new Exception("Alimento no encontrado");

            alimento.Nombre = dto.Nombre;
            alimento.Calorias = dto.Calorias;
            alimento.Proteinas = dto.Proteinas;
            alimento.Carbohidratos = dto.Carbohidratos;
            alimento.Grasas = dto.Grasas;
            alimento.Descripcion = dto.Descripcion;
            alimento.ID_Categoria = dto.ID_Categoria;
            alimento.ID_Objetivo = dto.ID_Objetivo;

            _repository.Update(alimento);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var alimento =
                await _repository.GetByIdAsync(id);

            if (alimento == null)
                throw new Exception("Alimento no encontrado");

            _repository.Remove(alimento);

            await _repository.SaveChangesAsync();
        }
    }
}