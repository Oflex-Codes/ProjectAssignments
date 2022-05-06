using ProjectAssignments.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAssignments.Models
{
    public class EmployeeDAO
    {
        public string EmpName { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.DateTime EmployementDate { get; set; }
        public decimal salary { get; set; }
        public int age { get; set; }
        public int VaxOrNot { get; set; }
        public Department Position { get; set; }
        public string admin { get; set; }
        public string password { get; set; }
    }
}