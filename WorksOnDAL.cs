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
    public class  WorksOnDAL
    {
        static string constr = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        static SqlConnection con = new SqlConnection(constr);

        public int AddWorksOnDetails(WorksOnBO ObjWorksOnBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddWorksOnDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", ObjWorksOnBO.Emp_ID);
                cmd.Parameters.AddWithValue("@ProjectID", ObjWorksOnBO.Proj_ID);
                cmd.Parameters.AddWithValue("@WorkHours", ObjWorksOnBO.WorkHours);
                cmd.Parameters.AddWithValue("@WorkHours_per_Week", ObjWorksOnBO.WorkHours_per_Week);
                cmd.Parameters.AddWithValue("@Work_Rate_per_hour", ObjWorksOnBO.Work_Rate_per_hour);
                cmd.Parameters.AddWithValue("@Work_Assign_Date", ObjWorksOnBO.Work_Assign_Date);
                cmd.Parameters.AddWithValue("@Work_Rel_Date", ObjWorksOnBO.Work_Rel_Date);
                con.Open();
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException("ID already exists");
                    Console.WriteLine("Already  Exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteWorksOnDetails(string EmpID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteWorksOnDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException("ID doesn't exists");
                    Console.WriteLine("ID doesnot Exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public int UpdateWorksOnDetails(WorksOnBO ObjWorksOnBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateWorksOnDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", ObjWorksOnBO.Emp_ID);
                cmd.Parameters.AddWithValue("@ProjectID", ObjWorksOnBO.Proj_ID);
                cmd.Parameters.AddWithValue("@WorkHours", ObjWorksOnBO.WorkHours);
                cmd.Parameters.AddWithValue("@WorkHours_per_Week", ObjWorksOnBO.WorkHours_per_Week);
                cmd.Parameters.AddWithValue("@Work_Rate_per_hour", ObjWorksOnBO.Work_Rate_per_hour);
                cmd.Parameters.AddWithValue("@Work_Assign_Date", ObjWorksOnBO.Work_Assign_Date);
                cmd.Parameters.AddWithValue("@Work_Rel_Date", ObjWorksOnBO.Work_Rel_Date);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException(" already exists");
                    Console.WriteLine("ID doesnot Exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public void ShowWorksOnDetails()
        {
            string EmpID, ProjID, WorkRatePerHour;
            int WorkHours, WorkHoursPerWeek;
            DateTime WorkAssignDate, WorkRelDate;
            SqlCommand cmd = new SqlCommand("sp_GetAllWorksOnDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader result = cmd.ExecuteReader();


            if (result.HasRows)
            {
                while (result.Read())
                {
                    EmpID = result.GetString(0);
                    ProjID = result.GetString(1);
                    WorkHours = result.GetInt32(3);
                    WorkHoursPerWeek = result.GetInt32(4);
                    WorkRatePerHour = result.GetString(5);
                    WorkAssignDate = result.GetDateTime(6);
                    WorkRelDate = result.GetDateTime(7);

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", EmpID, ProjID, WorkHours, WorkHoursPerWeek, WorkRatePerHour, WorkAssignDate, WorkRelDate);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");

            }
        }
    }
}
