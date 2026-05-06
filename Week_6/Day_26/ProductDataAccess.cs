using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace ConsoleApp2
{
    public class ProductDataAccess
    {
        private readonly string _connectionString;

        //  config code
        public ProductDataAccess()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(Product p)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("usp_InsertProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product inserted successfully.");

        }

        // GET ALL
        public void GetAllProducts()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("usp_GetAllProducts", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
            }


        }

        // UPDATE
        public void UpdateProduct(Product p)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("usp_UpdateProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product updated successfully.");

        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_DeleteProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Product deleted successfully.");
            }
        }

        // get product by id

        public void GetProductById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetProductById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

    cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                
                    if (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                
            }

}

    }
}
