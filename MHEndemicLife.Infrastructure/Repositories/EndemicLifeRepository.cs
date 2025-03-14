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

        // 取得所有資料
        public async Task<IEnumerable<EndemicLife>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM EndemicLife";
            return await connection.QueryAsync<EndemicLife>(sql);
        }

        // 取得單筆資料
        public async Task<EndemicLife?> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM EndemicLife WHERE EndemicLife_Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<EndemicLife>(sql, new { Id = id });
        }

        // 新增資料
        public async Task<int> Add(EndemicLife endemicLife)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"
                INSERT INTO EndemicLife (EndemicLife_Name, EndemicLife_Environment, EndemicLife_Area, EndemicLife_Season, EndemicLife_Time, EndemicLife_Notes)
                VALUES (@Name, @Environment, @Area, @Season, @Time, @Notes);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return await connection.ExecuteScalarAsync<int>(sql, endemicLife);
        }

        // 更新資料
        public async Task<bool> Update(EndemicLife endemicLife)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"
                UPDATE EndemicLife 
                SET EndemicLife_Name = @Name,
                    EndemicLife_Environment = @Environment,
                    EndemicLife_Area = @Area,
                    EndemicLife_Season = @Season,
                    EndemicLife_Time = @Time,
                    EndemicLife_Notes = @Notes
                WHERE EndemicLife_Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(sql, endemicLife);
            return rowsAffected > 0;
        }

        // 刪除資料
        public async Task<bool> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "DELETE FROM EndemicLife WHERE EndemicLife_Id = @Id";
            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
