using Dapper;
using MHEndemicLife.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MHEndemicLife.Infrastructure.Repositories
{
    public class EndemicLifeRepository
    {
        private readonly string _connectionString;

        public EndemicLifeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<EndemicLife>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM EndemicLife";
            return await connection.QueryAsync<EndemicLife>(sql);
        }
    }
}
