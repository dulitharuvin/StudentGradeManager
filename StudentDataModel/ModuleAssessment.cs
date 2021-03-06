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
    
    public partial class ModuleAssessment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleAssessment()
        {
            this.Result = new HashSet<Result>();
        }
    
        public System.Guid ModuleAssessmentID { get; set; }
        public System.Guid CourseModuleID { get; set; }
        public string ModuleAssessmentTitle { get; set; }
        public string ModuleAssessmentDescription { get; set; }
        public double PassingMark { get; set; }
        public double Weighting { get; set; }
        public Nullable<int> AssessmentType { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> Expired { get; set; }
    
        public virtual CourseModule CourseModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }
    }
}
