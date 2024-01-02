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

        public async Task AddAsync(Empleado empleado)
        {
            await _empleados.InsertOneAsync(empleado);
        }

        async Task IEmpleadoRepository.DeleteAsync(string id)
        {
            var filter = Builders<Empleado>.Filter.Eq(empleado => empleado.Id, id);
            await _empleados.DeleteOneAsync(filter);
        
        }

        public async Task<Empleado> GetByIdAsync(string id)
        {
            var filter = Builders<Empleado>.Filter.Eq(empleado => empleado.Id, id);
            return await _empleados.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Empleado empleado)
        {
            var filter = Builders<Empleado>.Filter.Eq(e => e.Id, id);

            var update = Builders<Empleado>.Update
                .Set(e => empleado.Apellido, empleado.Apellido) 
                .Set(empleado => empleado.Cargo, empleado.Cargo); 

            await _empleados.UpdateOneAsync(filter, update);
        }
    }
}
