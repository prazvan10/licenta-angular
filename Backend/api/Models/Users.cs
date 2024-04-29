using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;
    }
}