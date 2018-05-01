using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ModuleService" in both code and config file together.
    public class CourseModuleService : ICourseModuleService
    {
        public List<CourseModule> GetData()
        {
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                return context.CourseModule.ToList();
            }
        }

        public List<CourseModule> GetModulesByCourse(Course m)
        {
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                return context.CourseModule.Where(a => a.Course.CourseID.Equals(m.CourseID)).ToList();
            }
        }

        public int SaveModule(CourseModule m)
        {
            m.CreatedDate = DateTime.Now;
            m.UpdatedDate = DateTime.Now;
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                context.CourseModule.Add(m);
                return context.SaveChanges();
            }
        }
    }
}
