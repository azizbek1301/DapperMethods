using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperMethods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");


        [HttpGet("ExecuteScalar")]
        public IActionResult GetExecuteScalar()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test";
                var count = connection.ExecuteScalar(sql);

                Console.WriteLine($"Items : {count}");
                return Ok(count);
            }
        }
        [HttpGet("ExecuteScalarGeneric")]
        public IActionResult GetExecuteScalarGeneric()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test";
                var count = connection.ExecuteScalar<string>(sql);

                Console.WriteLine($"Total products: {count}");
                return Ok(count);
            }
        }

        [HttpGet("ExecuteScalarAsync")]
        public async Task<ActionResult> GetExecuteScalarAsync()
        {
            using (SqlConnection? connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT COUNT(*) FROM Test";
                var count = await connection.ExecuteScalarAsync(sql);

                Console.WriteLine($"Total products: {count}");
                return Ok(count);
            }
        }
    }
}
