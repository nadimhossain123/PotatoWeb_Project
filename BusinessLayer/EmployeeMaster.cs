using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class EmployeeMaster
    {
        public EmployeeMaster()
        {
        }

        public int Save(Entity.EmployeeMaster employeemaster)
        {
            return DataAccess.EmployeeMaster.Save(employeemaster);
        }

        public DataTable GetAll(int BranchId,int DesignationId,string FName)
        {
            return DataAccess.EmployeeMaster.GetAll(BranchId, DesignationId, FName);
        }

        public Entity.EmployeeMaster GetById(int employeeId)
        {
            return DataAccess.EmployeeMaster.GetById(employeeId);
        }

        public Entity.EmployeeMaster AuthenticateUser(string Email)
        {
            return DataAccess.EmployeeMaster.AuthenticateUser(Email);
        }

        public void ChangePassword(Entity.EmployeeMaster Employee)
        {
            DataAccess.EmployeeMaster.ChangePassword(Employee);
        }

        public DataTable GetAllServiceEngg(int BranchId)
        {
            return DataAccess.EmployeeMaster.GetAllServiceEngg(BranchId);
        }

        public DataTable EngineerPerformance(int branchId, int engineerId, DateTime startDate, DateTime endDate)
        {
            return DataAccess.EmployeeMaster.EngineerPerformance(branchId, engineerId, startDate, endDate);
        }
    }
}
