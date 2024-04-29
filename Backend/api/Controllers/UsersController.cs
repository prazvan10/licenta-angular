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
    }
}