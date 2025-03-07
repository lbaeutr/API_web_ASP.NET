using MongoDB.Driver;
using api_psp.Models;
using Microsoft.Extensions.Options;
using api_psp.Settings;

namespace api_psp.Services
{
    public class JugadorService
    {
        private readonly IMongoCollection<Jugador> _jugadoresCollection;

        public JugadorService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _jugadoresCollection = mongoDatabase.GetCollection<Jugador>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Jugador>> GetTop5JugadoresAsync() =>
            await _jugadoresCollection.Find(_ => true)
                                      .SortByDescending(j => j.Puntuacion)
                                      .Limit(5)
                                      .ToListAsync();

        public async Task<List<Jugador>> GetAllAsync() =>
            await _jugadoresCollection.Find(_ => true).ToListAsync();

        public async Task<Jugador> GetByIdAsync(string id) =>
            await _jugadoresCollection.Find(j => j.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task CreateAsync(Jugador jugador) =>
            await _jugadoresCollection.InsertOneAsync(jugador);

        public async Task UpdateAsync(string id, Jugador jugador) =>
            await _jugadoresCollection.ReplaceOneAsync(j => j.Id.Equals(id), jugador);

        public async Task DeleteAsync(string id) =>
            await _jugadoresCollection.DeleteOneAsync(j => j.Id.Equals(id));
    }
}
