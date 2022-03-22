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
    public class DeptDAL
    {
        static string constr = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        static SqlConnection con = new SqlConnection(constr);


        public int AddDepartmentDetails(DeptBO ObjDeptBO)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AddDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", ObjDeptBO.Dept_ID);
            cmd.Parameters.AddWithValue("@DepartmentName", ObjDeptBO.Dept_Name);
            cmd.Parameters.AddWithValue("@DepartmentLocation", ObjDeptBO.Dept_Location);
            cmd.Parameters.AddWithValue("@DepartmentPhone", ObjDeptBO.Dept_Phone);


            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                //throw new IdNotFoundException("ID already exist");
                Console.WriteLine("ID already Exists");
            }
            return result;
        }
        public int DeleteDepartmentDetails(string DeptID)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", DeptID);
            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                // throw new IdNotFoundException("ID doesn't exists");
                Console.WriteLine("ID doesnot Exists");
            }
            return result;

        }

        public int UpdateDepartmentDetails(DeptBO ObjDeptBO)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", ObjDeptBO.Dept_ID);
            cmd.Parameters.AddWithValue("@DepartmentName", ObjDeptBO.Dept_Name);
            cmd.Parameters.AddWithValue("@DepartmentLocation", ObjDeptBO.Dept_Location);
            cmd.Parameters.AddWithValue("@DepartmentPhone", ObjDeptBO.Dept_Phone);
            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                // throw new IdNotFoundException("ID already exists");
                Console.WriteLine("ID doesnot Exists");
            }
            return result;

        }
        public void ShowDepartmentDetails()
        {

            string DeptID, Dept_Name, Dept_Location, Dept_Phone;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader result = cmd.ExecuteReader();


            if (result.HasRows)
            {
                while (result.Read())
                {
                    DeptID = result.GetString(0);
                    Dept_Name = result.GetString(1);
                    Dept_Location = result.GetString(2);
                    Dept_Phone = result.GetString(3);

                    Console.WriteLine("{0}, {1}, {2}, {3}", DeptID, Dept_Name, Dept_Location, Dept_Phone);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");

            }
            result.Close();
            con.Close();
        }



    }
}

    }
}
