using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Domain.Abstract.NoSql.Entities;
using Accounting.Domain.Abstract.NoSql.Interfaces;
using Accounting.Settings.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Accounting.NoSqlDomain.Repositories
{
    public class PositionMongoRepository : IPositionNoSqlRepository
    {
        private readonly IMongoCollection<Position> _positions;

        public PositionMongoRepository(IAccountingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _positions = database.GetCollection<Position>(settings.PositionsCollectionName);
        }
        public async Task CreateAsync(Position item)
        {
            await _positions.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await (await _positions.FindAsync(position => true)).ToListAsync();
        }

        public async Task<Position> GetDetailsAsync(string id)
        {
            return await (await _positions
                    .FindAsync(s => s._id
                        .Equals(ObjectId.Parse(id))))
                .FirstOrDefaultAsync();
        }
    }
}
