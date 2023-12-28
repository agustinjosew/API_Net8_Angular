using GestionRecursosHumanos.API.Models;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace GestionRecursosHumanos.API.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly IMongoCollection<Departamento> _departamentos;

        public DepartamentoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("gestionRecursosHumanosDB");
            _departamentos = database.GetCollection<Departamento>("Departamentos");
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _departamentos.Find(departamento => true).ToListAsync();
        }

        public async Task AddAsync(Departamento departamento)
        {
            await _departamentos.InsertOneAsync(departamento);
        }

        async Task IDepartamentoRepository.DeleteAsync(string id)
        {
            var filter = Builders<Departamento>.Filter.Eq(departamento => departamento.Id, id);
            await _departamentos.DeleteOneAsync(filter);

        }

        public async Task<Departamento> GetByIdAsync(string id)
        {
            var filter = Builders<Departamento>.Filter.Eq(departamento => departamento.Id, id);
            return await _departamentos.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Departamento departamento)
        {
            var filter = Builders<Departamento>.Filter.Eq(d => d.Id, id);

            var update = Builders<Departamento>.Update
                .Set(d => departamento.Nombre, departamento.Nombre)
                .Set(d => departamento.Descripcion, departamento.Descripcion);

            await _departamentos.UpdateOneAsync(filter, update);
        }
    }
}
