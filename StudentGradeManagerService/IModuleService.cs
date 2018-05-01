using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StudentDataModel;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IModuleService" in both code and config file together.
    [ServiceContract]
    public interface IModuleService
    {
        [OperationContract]
        int SaveModule(CourseModule m);

        [OperationContract]
        List<CourseModule> GetData();

        [OperationContract]
        List<CourseModule> GetModulesByCourse(Course m);
    }
}
