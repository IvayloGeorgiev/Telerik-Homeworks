//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace H09EntityFrameworkPerformance.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHoursLog
    {
        public int LogID { get; set; }
        public string LogCommand { get; set; }
        public Nullable<int> OldTaskID { get; set; }
        public string OldTask { get; set; }
        public Nullable<int> OldEmployeeID { get; set; }
        public Nullable<System.DateTime> OldTaskDate { get; set; }
        public Nullable<int> OldHoursWorked { get; set; }
        public string OldComments { get; set; }
        public Nullable<int> NewTaskID { get; set; }
        public string NewTask { get; set; }
        public Nullable<int> NewEmployeeID { get; set; }
        public Nullable<System.DateTime> NewTaskDate { get; set; }
        public Nullable<int> NewHoursWorked { get; set; }
        public string NewComments { get; set; }
    }
}
