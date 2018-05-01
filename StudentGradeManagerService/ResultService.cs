using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResultService" in both code and config file together.
    public class ResultService : IResultService
    {
        public List<Result> GetData()
        {
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                return context.Result.ToList();
            }
        }

        public int SaveResult(Result r)
        {
            r.CreatedDate = DateTime.Now;
            r.UpdatedDate = DateTime.Now;
            using (var context = new STUDENT_GRADE_MANGEREntities())
            {
                context.Result.Add(r);
                return context.SaveChanges();
            }
        }
    }
}
