using AutoMapper;
using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using GestionRecursosHumanos.API.Services.Interfaces;
using MongoDB.Bson;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionRecursosHumanos.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IMapper _mapper;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public EmpleadoService(IEmpleadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmpleadoDTO>> GetAllEmpleadosAsync()
        {
            var empleados = await _repository.GetAllAsync();
            return _mapper.Map<List<EmpleadoDTO>>(empleados);
        }

        public async Task<EmpleadoDTO?> GetEmpleadoByIdAsync(string id)
        {
            var empleado = await _repository.GetByIdAsync(id);
            return empleado != null ? _mapper.Map<EmpleadoDTO>(empleado) : null;
        }

        public async Task CreateEmpleadoAsync(EmpleadoDTO empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            await _repository.AddAsync(empleado);
            logger.Info("Empleado creado correctamente: {EmpleadoId}", empleado.Id);
        }

        public async Task UpdateEmpleadoAsync(string id, EmpleadoDTO empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            empleado.Id = id; // Asegurarse de que el ID se mantiene
            await _repository.UpdateAsync(id, empleado);
            logger.Info("Empleado actualizado correctamente: {EmpleadoId}", empleado.Id);
        }

        public async Task DeleteEmpleadoAsync(string id)
        {
            await _repository.DeleteAsync(id);
            logger.Info("Empleado eliminado correctamente: {EmpleadoId}", id);
        }
    }
}
