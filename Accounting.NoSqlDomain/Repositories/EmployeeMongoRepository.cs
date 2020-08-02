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
    public class EmployeeMongoRepository : IEmployeeNoSqlRepository
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeMongoRepository(IAccountingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);
        }
        public async Task CreateAsync(Employee item)
        {
            await _employees.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                return await (await _employees.FindAsync(employee => true)).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> GetDetailsAsync(string id)
        {
            return (await _employees
                .FindAsync<Employee>(s => s._id
                    .Equals(ObjectId.Parse(id))))
                .FirstOrDefault();
        }
    }
}
