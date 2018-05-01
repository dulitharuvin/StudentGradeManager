using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataModel.DTO
{
    public class StudentDTO
    {
        public Guid StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Expired { get; set; }
    }
}
