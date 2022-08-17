using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int? UserType { get; set; }
        public string? Portestement { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Specialization { get; set; }
        public string? School { get; set; }  
        public int? PhoneNumber { get; set; }
        public string?   Image { get; set; }
        public string?   Sex { get; set; }


    }
}
