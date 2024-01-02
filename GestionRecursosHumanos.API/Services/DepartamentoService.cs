using AutoMapper;
using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using GestionRecursosHumanos.API.Services.Interfaces;
using NLog;

namespace GestionRecursosHumanos.API.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repository;
        private readonly IMapper _mapper;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger(); 

        public DepartamentoService(IDepartamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoDTO>> GetAllDepartamentosAsync()
        {
            var departamentos = await _repository.GetAllAsync();
            return _mapper.Map<List<DepartamentoDTO>>(departamentos);
        }

        public async Task<DepartamentoDTO?> GetDepartamentosByIdAsync(string id)
        {
            var departamento = await _repository.GetByIdAsync(id);
            return departamento != null ? _mapper.Map<DepartamentoDTO>(departamento) : null;
        }

        public async Task CreateDepartamentoAsync(DepartamentoDTO departamentoDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            await _repository.AddAsync(departamento);
            logger.Info("Departamento creado correctamente: {DepartamentoId}", departamento.Id);
        }

        public async Task UpdateDepartamentoAsync(string id, DepartamentoDTO departamentoDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            departamento.Id = id;
            await _repository.UpdateAsync(id, departamento);
            logger.Info("Departamento axtualizado correctamente {DepartamentoId}" , departamento.Id);
        }

        public async Task DeleteDepartamentoAsync(string id)
        {
           await _repository.DeleteAsync(id);
           logger.Info($"Departamento: {id} eliminado correctamente");
        }
    }
}
