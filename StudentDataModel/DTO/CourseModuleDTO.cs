using System;

namespace StudentDataModel.DTO
{
    public class CourseModuleDTO
    {
        public Guid CourseModuleID { get; set; }
        public Guid CourseID { get; set; }
        public string CourseModuleTitle { get; set; }
        public string CourseModuleCode { get; set; }
        public double CourseModuleCreditValue { get; set; }
        public string CourseModuleDescription { get; set; }
        public int ModuleType { get; set; }
        public int Level { get; set; }
        public bool ContributedToFinal { get; set; }
        public int Expired { get; set; }
    }
}
