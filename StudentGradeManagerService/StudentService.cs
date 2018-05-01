using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentService : IStudentService
    {
        public int SaveStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                context.Student.Add(student);
                return context.SaveChanges();
            }
        }

        public bool StudentLoginValidate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public IList<Course> GetStudentEnrolledCourses(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
