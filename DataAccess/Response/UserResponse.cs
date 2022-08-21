using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Response
{
    public class UserResponse
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int? UserType { get; set; }
        public string? Portestement { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Specialization { get; set; }
        public string? School { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public string? Sex { get; set; }
    }
}
