using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class EmployeeMaster
    {
        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int BranchId { get; set; }
        public int DesignationId { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Roles { get; set; }
        public int CreatedBy { get; set; }
        public string Address { get; set; }

    }
}
