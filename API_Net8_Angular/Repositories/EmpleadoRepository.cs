using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace GestionRecursosHumanos.API.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IMongoCollection<Empleado> _empleados;

        public EmpleadoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("gestionRecursosHumanosDB");
            _empleados = database.GetCollection<Empleado>("Empleados");
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _empleados.Find(empleado => true).ToListAsync();
        }

        Task IEmpleadoRepository.AddAsync(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        Task IEmpleadoRepository.DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Empleado> IEmpleadoRepository.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IEmpleadoRepository.UpdateAsync(string id, Empleado empleado)
        {
            throw new NotImplementedException();
        }
    }
}
