using System;
using System.Collections.Generic;

namespace SalesWebApi.Models
{
    public partial class VisitTable
    {
        public int VisitId { get; set; }
        public string CustName { get; set; }
        public string ContactPerson { get; set; }
        public int? ContactNo { get; set; }
        public string InterestProduct { get; set; }
        public string VisitSubject { get; set; }
        public string Description { get; set; }
        public DateTime? VisitDatetime { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsDeleted { get; set; }
        public int? EmpId { get; set; }

        public virtual EmployeeRegistration Emp { get; set; }
    }
}
