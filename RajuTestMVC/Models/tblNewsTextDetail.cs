//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RajuTestMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblNewsTextDetail
    {
        public int SNo { get; set; }
        public Nullable<int> NewsID { get; set; }
        public Nullable<int> LangID { get; set; }
        public string Text { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> Updatedby { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual tblNewsDetail tblNewsDetail { get; set; }
    }
}