//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Result
    {
        public System.Guid ResultID { get; set; }
        public System.Guid ModuleAssessmentID { get; set; }
        public double Mark { get; set; }
        public double PredictedMark { get; set; }
        public Nullable<int> Grade { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> Expired { get; set; }
    
        public virtual ModuleAssessment ModuleAssessment { get; set; }
    }
}
