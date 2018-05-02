using System;

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
