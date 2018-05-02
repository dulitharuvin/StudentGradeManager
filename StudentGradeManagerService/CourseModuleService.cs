using System;
using System.Collections.Generic;
using System.Linq;
using StudentDataModel;
using StudentDataModel.DTO;
using StudentDataModel.AutoMapper;
using AutoMapper.QueryableExtensions;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ModuleService" in both code and config file together.
    public class CourseModuleService : ICourseModuleService
    {
        public int SaveCourseModule(CourseModule m)
        {
            m.CreatedDate = DateTime.Now;
            m.UpdatedDate = DateTime.Now;
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    context.CourseModule.Add(m);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return 0;
            }
        }

        public List<CourseModule> GetCourseModules()
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

        public List<CourseModuleDTO> GetModulesByCourseAndLevel(Guid courseId, int moduleLevel)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    return context.CourseModule.
                        Where(a => a.Course.CourseID.Equals(courseId) && a.Level == moduleLevel)
                        .ProjectTo<CourseModuleDTO>()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }
    }
}
