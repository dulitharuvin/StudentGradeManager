using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;
using StudentDataModel.DTO;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IModuleService" in both code and config file together.
    [ServiceContract]
    public interface ICourseModuleService
    {
        [OperationContract]
        int SaveCourseModule(CourseModule m);

        [OperationContract]
        List<CourseModule> GetCourseModules();

        [OperationContract]
        List<CourseModule> GetModulesByCourse(Course m);

        [OperationContract]
        List<CourseModuleDTO> GetModulesByCourseAndLevel(Guid courseId, int moduleLevel);
    }
}
