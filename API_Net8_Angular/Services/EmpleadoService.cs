using GestionRecursosHumanos.API.DTOs;
using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using GestionRecursosHumanos.API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using NLog;

namespace GestionRecursosHumanos.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public EmpleadoService(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmpleadoDTO>> GetAllEmpleadosAsync()
        {
            var empleados = await _repository.GetAllAsync();
            return empleados.Select(empleado => new EmpleadoDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Email = empleado.Email,
                Cargo = empleado.Cargo,
                DepartamentoId = empleado.DepartamentoId.ToString(),
                PuestoId = empleado.PuestoId.ToString(),
                
            }).ToList();

        }

        public async Task CreateEmpleadoAsync(EmpleadoDTO empleadoDto)
        {
            try
            {
                var empleado = new Empleado
                {
                    Id = empleadoDto.Id,
                    Nombre = empleadoDto.Nombre,
                    Apellido = empleadoDto.Apellido,
                    Email = empleadoDto.Email,
                    Cargo = empleadoDto.Cargo,
                    DepartamentoId = ObjectId.Parse(empleadoDto.DepartamentoId),
                    PuestoId = ObjectId.Parse(empleadoDto.PuestoId)
                };

                
                await _repository.AddAsync(empleado);
                
                logger.Info("Empleado creado correctamente: {EmpleadoId}", empleado.Id);
            }
            catch (FormatException ex)
            {                
                logger.Error(ex, "Formato invalido para el Id: {ErrorMessage}", ex.Message);                
                throw new ArgumentException("Formato invalido para Departamento o Posicion.");
            }
            catch (MongoException ex)
            {
                // Manejar excepciones puntuales de MongoDB
                logger.Error(ex, "MongoDB error: {ErrorMessage}", ex.Message);                
                
                throw new ApplicationException("Un error ha ocurrido mientras se creaba al empleado.");
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                logger.Error(ex, "Ocurrio un error: {ErrorMessage}", ex.Message);
                
                throw new ApplicationException("Un error ha ocurrido al crear al empleado.");
            }
        }
        Task IEmpleadoService.DeleteEmpleadoAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<EmpleadoDTO> IEmpleadoService.GetEmpleadoByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IEmpleadoService.UpdateEmpleadoAsync(string id, EmpleadoDTO empleadoDto)
        {
            throw new NotImplementedException();
        }
    }
}
