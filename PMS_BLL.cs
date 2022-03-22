using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using BO;
using DAL;


namespace BLL
{
    public class PMS_BLL
    {
        public int AddDepartment(DeptBO ObjD)
        {
            DeptDAL ObjDA = new DAL.DeptDAL();
            return ObjDA.AddDepartmentDetails(ObjD);
        }

        public int DeleteDepartment(string Did)
        {
            DeptDAL ObjDA = new DAL.DeptDAL();
            return ObjDA.DeleteDepartmentDetails(Did);
        }

        public int UpdateDepartment(DeptBO ObjD)
        {
            DeptDAL ObjDA = new DAL.DeptDAL();
            return ObjDA.UpdateDepartmentDetails(ObjD);
        }

        public void ShowDepartment()
        {
            DeptDAL ObjDA = new DAL.DeptDAL();
            ObjDA.ShowDepartmentDetails();
        }

        public int AddEmployee(EmpBO ObjE)
        {
            EmpDAL ObjEA = new DAL.EmpDAL();
            return ObjEA.AddEmployeeDetails(ObjE);
        }
        public int UpdateEmployee(EmpBO ObjE)
        {
            EmpDAL ObjEA = new DAL.EmpDAL();
            return ObjEA.UpdateEmployeeDetails(ObjE);
        }
        public int DeleteEmployee(string Eid)
        {
            EmpDAL ObjEA = new DAL.EmpDAL();
            return ObjEA.DeleteEmployeeDetails(Eid);
        }
        public void ShowEmployee()
        {
            EmpDAL ObjEA = new DAL.EmpDAL();
            ObjEA.ShowEmployeeDetails();
        }

        public int AddProject(ProjBO ObjP)
        {
            ProjDAL ObjPA = new DAL.ProjDAL();
            return ObjPA.AddProjectDetails(ObjP);
        }
        public int UpdateProject(ProjBO ObjP)
        {
            ProjDAL ObjPA = new DAL.ProjDAL();
            return ObjPA.UpdateProjectDetails(ObjP);
        }
        public int DeleteProject(string ProjID)
        {
            ProjDAL ObjPA = new DAL.ProjDAL();
            return ObjPA.DeleteProjectDetails(ProjID);
        }
        public void ShowProject()
        {
            ProjDAL ObjPA = new DAL.ProjDAL();
            ObjPA.ShowProjectDetails();
        }

        public int AddWorksOn(WorksOnBO ObjW)
        {
            WorksOnDAL ObjWA = new DAL.WorksOnDAL();
            return ObjWA.AddWorksOnDetails(ObjW);
        }
        public int UpdateWorksOn(WorksOnBO ObjW)
        {
            WorksOnDAL ObjWA = new DAL.WorksOnDAL();
            return ObjWA.UpdateWorksOnDetails(ObjW);
        }
        public int DeleteWorksOn(string EmpID)
        {
            WorksOnDAL ObjWA = new DAL.WorksOnDAL();
            return ObjWA.DeleteWorksOnDetails(EmpID);
        }
        public void ShowWorksOn()
        {
            WorksOnDAL ObjWA = new DAL.WorksOnDAL();
            ObjWA.ShowWorksOnDetails();
        }
    }
}
