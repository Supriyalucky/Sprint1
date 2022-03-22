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
    public class  ProjDAL
    {
        static string constr = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        static SqlConnection con = new SqlConnection(constr);

        public int AddProjectDetails(ProjBO ObjProjBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", ObjProjBO.Proj_ID);
                cmd.Parameters.AddWithValue("@DepartmentID", ObjProjBO.Dept_ID);
                cmd.Parameters.AddWithValue("@ProjectName", ObjProjBO.Proj_Name);
                cmd.Parameters.AddWithValue("@ProjectBudjet", ObjProjBO.Proj_Budjet);
                cmd.Parameters.AddWithValue("@ProjectStartDate", ObjProjBO.Proj_Start_Date);
                cmd.Parameters.AddWithValue("@ProjectEndDate", ObjProjBO.Proj_End_Date);


                con.Open();
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException("ID alreadty exist");
                    Console.WriteLine(" ID already exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteProjectDetails(string ProjID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", ProjID);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //throw new IdNotFoundException("ID doesn't exists");
                    Console.WriteLine(" ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateProjectDetails(ProjBO ObjProjBO)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", ObjProjBO.Proj_ID);
                cmd.Parameters.AddWithValue("@DepartmentID", ObjProjBO.Dept_ID);
                cmd.Parameters.AddWithValue("@ProjectName", ObjProjBO.Proj_Name);
                cmd.Parameters.AddWithValue("@ProjectBudjet", ObjProjBO.Proj_Budjet);
                cmd.Parameters.AddWithValue("@ProjectStartDate", ObjProjBO.Proj_Start_Date);
                cmd.Parameters.AddWithValue("@ProjectEndDate", ObjProjBO.Proj_End_Date);

                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //throw new IdNotFoundException("ID already exists");
                    Console.WriteLine(" ID doesnot exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public void ShowProjectDetails()
        {
            string ProjID, DeptID, ProjName, ProjBudjet;
            DateTime ProjStartDate, ProjEndDate;
            SqlCommand cmd = new SqlCommand("sp_GetAllProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader result = cmd.ExecuteReader();


            if (result.HasRows)
            {
                while (result.Read())
                {
                    ProjID = result.GetString(0);
                    DeptID = result.GetString(1);
                    ProjName = result.GetString(2);
                    ProjBudjet = result.GetString(3);
                    ProjStartDate = result.GetDateTime(4);
                    ProjEndDate = result.GetDateTime(5);

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", ProjID, DeptID, ProjName, ProjBudjet, ProjStartDate, ProjEndDate);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");

            }
        }

    }
}
