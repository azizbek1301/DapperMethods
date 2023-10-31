using Dapper;
using DapperMethods.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet("ExecuteScalarAsyncGeneric")]
        public async Task<ActionResult> GetExecuteScalarAsyncGeneric()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT COUNT(*) FROM Test";
                var count = await connection.ExecuteScalarAsync<int>(sql);

                Console.WriteLine($"Total products: {count}");
                return Ok(count);
            }
        }
        [HttpGet("QuerySingle")]
        public IActionResult GetQuerySingle()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test WHERE id = 1";
                var product = connection.QuerySingle(sql);

                Console.WriteLine($"{product.id} {product.name}");
                return Ok(product);
            }
        }
        [HttpGet("QuerySingleGeneric")]
        public IActionResult GetQuerySingleGeneric()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test WHERE id = 2";
                var product = connection.QuerySingle<string>(sql);

                
                return Ok(product);
            }
        }
        [HttpGet("QuerySingleAsync")]
        public async Task<ActionResult> GetQuerySingleAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Test WHERE id = 2";
                var customer = await connection.QuerySingleAsync(sql);

                return Ok(customer);
            }
        }

        [HttpGet("QuerySingleAsyncGeneric")]
        public async Task<ActionResult> GetQuerySingleAsyncGeneric()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test WHERE id = 1";
                var customer = await connection.QuerySingleAsync<User>(sql);

                Console.WriteLine($"{customer.name} {customer.age}");
                return Ok(customer);
            }
        }

        [HttpGet("QueryFirst")]
        public IActionResult QueryFirst()
        {
            string sql = "SELECT * FROM Test WHERE id=2";
            using (var connection = new SqlConnection(connectionString))
            {
                var customer = connection.QueryFirst<User>(sql);
                Console.WriteLine(customer.name);
                Console.WriteLine(customer.age);
                return Ok(customer);
            }
        }

        [HttpGet("QueryFirstAsync")]
        public async Task<ActionResult> QueryFirstAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test WHERE id = 1";
                var customer = await connection.QueryFirstAsync<User>(sql);

                Console.WriteLine($"{customer.name} {customer.age}");
                return Ok(customer);
            }
        }

        [HttpGet("Query")]
        public IActionResult Query()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test";
                var customers = connection.Query(sql);

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.name} {customer.age}");
                }
                return Ok(customers);
            }
        }
        [HttpGet("QueryAsync")]
        public async Task<ActionResult> QueryAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Test";
                var customers = await connection.QueryAsync(sql);

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.CustomerID} {customer.CompanyName}");
                }
                return Ok(customers);
            }
        }

    }
}
