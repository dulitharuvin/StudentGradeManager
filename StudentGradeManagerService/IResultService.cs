using StudentDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentGradeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResultService" in both code and config file together.
    [ServiceContract]
    public interface IResultService
    {
        [OperationContract]
        int SaveResult(Result r);

        [OperationContract]
        List<Result> GetData();

    }
}
