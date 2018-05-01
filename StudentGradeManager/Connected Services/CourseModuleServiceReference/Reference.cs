﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentGradeManager.CourseModuleServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CourseModuleServiceReference.ICourseModuleService")]
    public interface ICourseModuleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/SaveModule", ReplyAction="http://tempuri.org/ICourseModuleService/SaveModuleResponse")]
        int SaveModule(StudentDataModel.CourseModule m);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/SaveModule", ReplyAction="http://tempuri.org/ICourseModuleService/SaveModuleResponse")]
        System.Threading.Tasks.Task<int> SaveModuleAsync(StudentDataModel.CourseModule m);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/GetData", ReplyAction="http://tempuri.org/ICourseModuleService/GetDataResponse")]
        StudentDataModel.CourseModule[] GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/GetData", ReplyAction="http://tempuri.org/ICourseModuleService/GetDataResponse")]
        System.Threading.Tasks.Task<StudentDataModel.CourseModule[]> GetDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/GetModulesByCourse", ReplyAction="http://tempuri.org/ICourseModuleService/GetModulesByCourseResponse")]
        StudentDataModel.CourseModule[] GetModulesByCourse(StudentDataModel.Course m);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseModuleService/GetModulesByCourse", ReplyAction="http://tempuri.org/ICourseModuleService/GetModulesByCourseResponse")]
        System.Threading.Tasks.Task<StudentDataModel.CourseModule[]> GetModulesByCourseAsync(StudentDataModel.Course m);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICourseModuleServiceChannel : StudentGradeManager.CourseModuleServiceReference.ICourseModuleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CourseModuleServiceClient : System.ServiceModel.ClientBase<StudentGradeManager.CourseModuleServiceReference.ICourseModuleService>, StudentGradeManager.CourseModuleServiceReference.ICourseModuleService {
        
        public CourseModuleServiceClient() {
        }
        
        public CourseModuleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CourseModuleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CourseModuleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CourseModuleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int SaveModule(StudentDataModel.CourseModule m) {
            return base.Channel.SaveModule(m);
        }
        
        public System.Threading.Tasks.Task<int> SaveModuleAsync(StudentDataModel.CourseModule m) {
            return base.Channel.SaveModuleAsync(m);
        }
        
        public StudentDataModel.CourseModule[] GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<StudentDataModel.CourseModule[]> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
        
        public StudentDataModel.CourseModule[] GetModulesByCourse(StudentDataModel.Course m) {
            return base.Channel.GetModulesByCourse(m);
        }
        
        public System.Threading.Tasks.Task<StudentDataModel.CourseModule[]> GetModulesByCourseAsync(StudentDataModel.Course m) {
            return base.Channel.GetModulesByCourseAsync(m);
        }
    }
}