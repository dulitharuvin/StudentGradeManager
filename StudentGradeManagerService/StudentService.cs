using System;
using System.Collections.Generic;
using System.Linq;
using StudentDataModel;
using StudentDataModel.DTO;
using AutoMapper.QueryableExtensions;
using StudentDataModel.AutoMapper;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentService : IStudentService
    {
        public int SaveStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    context.Student.Add(student);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return 0;
            }

        }

        public StudentDTO StudentLoginValidate(string userName, string password)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    var student = context.Student.Where(st => string.Equals(st.UserName, userName) && string.Equals(st.Password, password))
                        .ProjectTo<StudentDTO>()
                        .FirstOrDefault();
                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public Student GetStudentById(Guid studentId)
        {
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    var student = context.Student.Where(st => st.StudentID == studentId)
                        .FirstOrDefault();
                    return student;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public List<CourseDTO> GetStudentEnrolledCourses(Guid studentId)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    var studentCourses = context.Course.Where(st => st.StudentID == studentId)
                        .ProjectTo<CourseDTO>()
                        .ToList();
                    return studentCourses;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
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
