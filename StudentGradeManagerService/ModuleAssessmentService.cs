using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ModuleAssessmentService" in both code and config file together.
    public class ModuleAssessmentService : IModuleAssessmentService
    {
        public List<ModuleAssessment> GetAssesmentsByModule(CourseModule c)
        {
            if(c != null)
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    return context.ModuleAssessment.Where(a => a.CourseModule.CourseModuleID.Equals(c.CourseModuleID)).ToList();
                }
            }
            return new List<ModuleAssessment>();
        }

        public List<ModuleAssessment> GetData()
        {
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                return context.ModuleAssessment.ToList();
            }
        }

        public int SaveAssessment(ModuleAssessment r)
        {
            r.CreatedDate = DateTime.Now;
            r.UpdatedDate = DateTime.Now;
            try
            {
                using (var context = new STUDENT_GRADE_MANGEREntities())
                {
                    context.ModuleAssessment.Add(r);
                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return 0;
            }
        }
    }
}
