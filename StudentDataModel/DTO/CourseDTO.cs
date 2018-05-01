using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataModel.DTO
{
    public class CourseDTO
    {
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int Expired { get; set; }
    }
}
