using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using api.Models;


namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=agora;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly ApplicationDBContext _context;
        public UsersController(ApplicationDBContext context)
        {
            _context=context;
        }

        // GET: api/ManageUsers
        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsersItems()
        {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string sql = "SELECT * FROM Users";
        SqlCommand command = new SqlCommand(sql, connection);
        SqlDataReader dataReader = command.ExecuteReader();
        var initialJson = "[]";
        var array = JArray.Parse(initialJson);
        var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
        while(dataReader.Read())
        {
        var itemToAdd = new JObject();
        itemToAdd["UserID"] = dataReader["UserID"].ToString();
        itemToAdd["UserName"] = dataReader["UserName"].ToString();
        itemToAdd["UserPassword"] = dataReader["UserPassword"].ToString();
        itemToAdd["FirstName"] = dataReader["FirstName"].ToString();
        itemToAdd["LastName"] = dataReader["LastName"].ToString();
        itemToAdd["Email"] = dataReader["Email"].ToString();
        itemToAdd["Telephone"] = dataReader["Telephone"].ToString();
        array.Add(itemToAdd);
        }
        jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
        return Ok(jsonToOutput);
        }

                // POST: api/ManageUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "PostUsers")]
        public IActionResult PostUserItem(Users userItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "INSERT INTO Users (UserName, UserPassword, FirstName, LastName, Email, Telephone) VALUES (@UserName, @UserPassword, @FirstName, @LastName, @Email, @Telephone)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserName", userItem.UserName);
            command.Parameters.AddWithValue("@UserPassword", userItem.UserPassword);
            command.Parameters.AddWithValue("@FirstName", userItem.FirstName);
            command.Parameters.AddWithValue("@LastName", userItem.LastName);
            command.Parameters.AddWithValue("@Email", userItem.Email);
            command.Parameters.AddWithValue("@Telephone", userItem.Telephone);
            command.ExecuteNonQuery();
            connection.Close();
            return Ok();
        }

        [HttpGet("Username")]
        public IActionResult GetUserItemByName(string username)
        {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string sql = "SELECT * FROM Users WHERE UserName=@UserName";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserName", username);
        SqlDataReader dataReader = command.ExecuteReader();
        JObject jsonItem =new JObject();
        var jsonToOutput = JsonConvert.SerializeObject(jsonItem, Formatting.Indented);
        while(dataReader.Read())
        {
        jsonItem["UserID"] = dataReader["UserID"].ToString();
        jsonItem["UserName"] = dataReader["UserName"].ToString();
        jsonItem["UserPassword"] = dataReader["UserPassword"].ToString();
        jsonItem["FirstName"] = dataReader["FirstName"].ToString();
        jsonItem["LastName"] = dataReader["LastName"].ToString();
        jsonItem["Email"] = dataReader["Email"].ToString();
        jsonItem["Telephone"] = dataReader["Telephone"].ToString();
        }
        jsonToOutput = JsonConvert.SerializeObject(jsonItem, Formatting.Indented);
        return Ok(jsonToOutput);
        }

        [HttpGet("Id")]
        public IActionResult GetUserItemById(int id)
        {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string sql = "SELECT * FROM Users WHERE UserId=@ID";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@ID", id);
        SqlDataReader dataReader = command.ExecuteReader();
        JObject jsonItem =new JObject();
        var jsonToOutput = JsonConvert.SerializeObject(jsonItem, Formatting.Indented);
        while(dataReader.Read())
        {
        jsonItem["UserID"] = dataReader["UserID"].ToString();
        jsonItem["UserName"] = dataReader["UserName"].ToString();
        jsonItem["UserPassword"] = dataReader["UserPassword"].ToString();
        jsonItem["FirstName"] = dataReader["FirstName"].ToString();
        jsonItem["LastName"] = dataReader["LastName"].ToString();
        jsonItem["Email"] = dataReader["Email"].ToString();
        jsonItem["Telephone"] = dataReader["Telephone"].ToString();
        }
        jsonToOutput = JsonConvert.SerializeObject(jsonItem, Formatting.Indented);
        return Ok(jsonToOutput);
        }
    }
}