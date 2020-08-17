using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class EmployeeMaster
    {
        public EmployeeMaster()
        {
        }

        public static int Save(Entity.EmployeeMaster employeemaster)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@EmployeeId", SqlDbType.Int, employeemaster.EmployeeId);
                oDm.Add("@FName", SqlDbType.VarChar, 50, employeemaster.FName);
                oDm.Add("@LName", SqlDbType.VarChar, 50, employeemaster.LName);
                oDm.Add("@Email", SqlDbType.VarChar, 50, employeemaster.Email);
                oDm.Add("@ContactNo", SqlDbType.VarChar, 50, employeemaster.ContactNo);
                oDm.Add("@BranchId", SqlDbType.Int, employeemaster.BranchId);
                oDm.Add("@DesignationId", SqlDbType.Int, employeemaster.DesignationId);
                oDm.Add("@Status", SqlDbType.Bit, employeemaster.Status);
                oDm.Add("@Password", SqlDbType.VarChar, 20, employeemaster.Password);
                oDm.Add("@CreatedBy", SqlDbType.Int, employeemaster.CreatedBy);
                //oDm.Add("@Address", SqlDbType.VarChar, 200, employeemaster.Address);
                
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteNonQuery("EmployeeMaster_Save");
            }
        }

        public static DataTable GetAll(int BranchId, int DesignationId, string FName)
        {
            using (DataManager oDm = new DataManager())
            {
                if (BranchId > 0)
                    oDm.Add("@BranchId", SqlDbType.Int, BranchId);
                else
                    oDm.Add("@BranchId", SqlDbType.Int, DBNull.Value);

                if (DesignationId > 0)
                    oDm.Add("@DesignationId", SqlDbType.Int, DesignationId);
                else
                    oDm.Add("@DesignationId", SqlDbType.Int, DBNull.Value);

                if (FName.Trim().Length > 0)
                    oDm.Add("@FName", SqlDbType.VarChar, 50, FName);
                else
                    oDm.Add("@FName", SqlDbType.VarChar, 50, DBNull.Value);

                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("EmployeeMaster_GetAll");
            }
        }

        public static Entity.EmployeeMaster GetById(int employeeId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@EmployeeId", SqlDbType.Int, ParameterDirection.Input, employeeId);
                SqlDataReader dr = oDm.ExecuteReader("EmployeeMaster_GetById");

                Entity.EmployeeMaster employeeMaster = new Entity.EmployeeMaster();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeeMaster.EmployeeId = employeeId;
                        employeeMaster.FName = (dr[1] == DBNull.Value) ? "" : dr[1].ToString();
                        employeeMaster.LName = (dr[2] == DBNull.Value) ? "" : dr[2].ToString();
                        employeeMaster.Email = (dr[3] == DBNull.Value) ? "" : dr[3].ToString();
                        employeeMaster.ContactNo = (dr[4] == DBNull.Value) ? "" : dr[4].ToString();
                        employeeMaster.BranchId = (dr[5] == DBNull.Value) ? 0 : int.Parse(dr[5].ToString());
                        employeeMaster.DesignationId = (dr[6] == DBNull.Value) ? 0 : int.Parse(dr[6].ToString());
                        employeeMaster.Status = (dr[7] == DBNull.Value) ? false : Convert.ToBoolean(dr[7]);
                        employeeMaster.Password = (dr[8] == DBNull.Value) ? "" : dr[8].ToString();
                        employeeMaster.Address = (dr[9] == DBNull.Value) ? "" : dr[9].ToString();
                    }
                }
                return employeeMaster;
            }
        }

        public static Entity.EmployeeMaster AuthenticateUser(string Email)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@Email", SqlDbType.VarChar, 50, Email);
                oDm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = oDm.ExecuteReader("GetUserNameAndPass");
                Entity.EmployeeMaster Employee = new Entity.EmployeeMaster();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee.EmployeeId = (dr[0] == DBNull.Value) ? 0 : Convert.ToInt32(dr[0].ToString());
                        Employee.DesignationId = (dr[1] == DBNull.Value) ? 0 : Convert.ToInt32(dr[1].ToString());
                        Employee.Email = (dr[2] == DBNull.Value) ? "" : dr[2].ToString();
                        Employee.Password = (dr[3] == DBNull.Value) ? "" : dr[3].ToString();
                        Employee.Roles = (dr[4] == DBNull.Value) ? "" : dr[4].ToString();
                    }
                    return Employee;
                }
                return null;
            }
        }

        public static void ChangePassword(Entity.EmployeeMaster Employee)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@EmployeeId", SqlDbType.Int, ParameterDirection.Input, Employee.EmployeeId);
                oDm.Add("@Password", SqlDbType.VarChar, 50, Employee.Password);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("ChangePassword");
            }
        }

        public static DataTable GetAllServiceEngg(int BranchId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@BranchId", SqlDbType.Int, BranchId);
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("EmployeeMaster_GetAllServiceEngg");
            }
        }

        public static DataTable EngineerPerformance(int branchId, int engineerId, DateTime startDate, DateTime endDate)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                if (branchId == 0)
                    oDm.Add("@pBranchId", SqlDbType.Int, DBNull.Value);
                else
                    oDm.Add("@pBranchId", SqlDbType.Int, branchId);
                if (engineerId == 0)
                    oDm.Add("@pEngineerId", SqlDbType.Int, DBNull.Value);
                else
                    oDm.Add("@pEngineerId", SqlDbType.Int, engineerId);
                if (startDate == DateTime.MinValue)
                    oDm.Add("@StartDate", SqlDbType.DateTime, DBNull.Value);
                else
                    oDm.Add("@StartDate", SqlDbType.DateTime, startDate);
                if (endDate == DateTime.MinValue)
                    oDm.Add("@pEndDate", SqlDbType.DateTime, DBNull.Value);
                else
                    oDm.Add("@pEndDate", SqlDbType.DateTime, endDate);

                return oDm.ExecuteDataTable("usp_EngineerPerofrmanceReport");
            }
        }
    }
}
