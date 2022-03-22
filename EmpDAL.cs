using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class EmpDAL
    {
        static string constr = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        static SqlConnection con = new SqlConnection(constr);

        public int AddEmployeeDetails(EmpBO ObjEmpBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", ObjEmpBO.Emp_ID);
                cmd.Parameters.AddWithValue("@DepartmentID", ObjEmpBO.Dept_ID);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", ObjEmpBO.Emp_FirstName);
                cmd.Parameters.AddWithValue("@EmployeeMiddleName", ObjEmpBO.Emp_MiddleName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", ObjEmpBO.Emp_LastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", ObjEmpBO.Emp_Address);
                cmd.Parameters.AddWithValue("@EmployeeDOB", ObjEmpBO.Emp_DOB);
                cmd.Parameters.AddWithValue("@EmployeeDOJ", ObjEmpBO.Emp_DOJ);
                cmd.Parameters.AddWithValue("@EmployeeQualification", ObjEmpBO.Emp_Qua);
                con.Open();
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //throw new IdNotFoundException("Employee ID already exists");
                    Console.WriteLine("Employee ID already exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteEmployeeDetails(string EmpID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException("Employee ID doesn't exists");
                    Console.WriteLine("Employee ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public int UpdateEmployeeDetails(EmpBO ObjEmpBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", ObjEmpBO.Emp_ID);
                cmd.Parameters.AddWithValue("@DepartmentID", ObjEmpBO.Dept_ID);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", ObjEmpBO.Emp_FirstName);
                cmd.Parameters.AddWithValue("@EmployeeMiddleName", ObjEmpBO.Emp_MiddleName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", ObjEmpBO.Emp_LastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", ObjEmpBO.Emp_Address);
                cmd.Parameters.AddWithValue("@EmployeeDOB", ObjEmpBO.Emp_DOB);
                cmd.Parameters.AddWithValue("@EmployeeDOJ", ObjEmpBO.Emp_DOJ);
                cmd.Parameters.AddWithValue("@EmployeeQualification", ObjEmpBO.Emp_Qua);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //  throw new IdNotFoundException("Employee ID already exists");
                    Console.WriteLine("Employee ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public void ShowEmployeeDetails()
        {
            string EmpID, DeptID, EmpFirstName, EmpMiddleName, EmpLastName, EmpAddress, EmpQua;
            DateTime EmpDOB, EmpDOJ;
            SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader result = cmd.ExecuteReader();


            if (result.HasRows)
            {
                while (result.Read())
                {
                    EmpID = result.GetString(0);
                    DeptID = result.GetString(1);
                    EmpFirstName = result.GetString(2);
                    EmpMiddleName = result.GetString(3);
                    EmpLastName = result.GetString(4);
                    EmpAddress = result.GetString(5);
                    EmpDOB = result.GetDateTime(6);
                    EmpDOJ = result.GetDateTime(7);
                    EmpQua = result.GetString(8);

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", EmpID, DeptID, EmpFirstName, EmpMiddleName, EmpLastName, EmpAddress, EmpDOB, EmpDOJ, EmpQua);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");


            }


        }
    }
}
    }
}
