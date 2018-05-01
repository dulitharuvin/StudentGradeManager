using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CourseService" in both code and config file together.
    public class CourseService : ICourseService
    {
        public List<Course> DoWork()
        {
            using (var context = new STUDENT_GRADE_MANGEREntities())
            { 
                return context.Course.ToList();
            }
        }

        public int SaveCourse(Course c)
        {
            c.CreatedDate = DateTime.Now;
            c.UpdatedDate = DateTime.Now;
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                context.Course.Add(c);
                return context.SaveChanges();
            }
        }
    }
}
