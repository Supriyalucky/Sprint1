using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BLL;
using BO;


namespace Sprint1
{
    class Program
    {
        static void Main(string[] args)
        {
            PMS_BLL obj_pms = new PMS_BLL();
            EmpBO E = new EmpBO();
            DeptBO D = new DeptBO();
            ProjBO P = new ProjBO();
            WorksOnBO W = new WorksOnBO();

            Console.WriteLine("Enter Admin Username :");
            string AdminID = Console.ReadLine();
            Console.WriteLine("Enter password");
            string pass = Console.ReadLine();
            if (AdminID == "charvith" && pass == "123")
            {
                Console.WriteLine("Login Successful!!");
                Console.ReadLine();
                while (true)
                {

                    Console.WriteLine("----------------Welcome---------------");
                    Console.WriteLine("----------------Project Management System---------------");
                    Console.WriteLine("1) Employee Maintenance");
                    Console.WriteLine("2) Department Maintenance");
                    Console.WriteLine("3) Project Maintenance");
                    Console.WriteLine("4) WorksOn Maintenance");
                    Console.WriteLine("Enter your choice:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("----------- Employee Maintenance -----------");
                            Console.WriteLine("1) Add New Employee");
                            Console.WriteLine("2) Delete Existing Employee");
                            Console.WriteLine("3) Update Existing Employee Details");
                            Console.WriteLine("4) Fetch Employee Details");
                            Console.WriteLine("Enter your choice:");
                            int Empchoice = Convert.ToInt32(Console.ReadLine());

                            switch (Empchoice)
                            {
                                case 1:

                                    Console.WriteLine("Enter the Employee ID : ");
                                    E.Emp_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Deprtment ID : ");
                                    E.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee First Name : ");
                                    E.Emp_FirstName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Middle Name : ");
                                    E.Emp_MiddleName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Last Name : ");
                                    E.Emp_LastName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Address : ");
                                    E.Emp_Address = Console.ReadLine();
                                    Console.WriteLine("Enter the Date of Birth : ");
                                    E.Emp_DOB = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Date of Joining : ");
                                    E.Emp_DOJ = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter Qualification : ");
                                    E.Emp_Qua = Console.ReadLine();

                                    obj_pms.AddEmployee(E);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Employee ID to Delete Details");
                                    string delEmpID = Console.ReadLine();
                                    obj_pms.DeleteEmployee(delEmpID);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Employee ID to Update Details");
                                    E.Emp_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Deprtment ID : ");
                                    E.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee First Name : ");
                                    E.Emp_FirstName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Middle Name : ");
                                    E.Emp_MiddleName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Last Name : ");
                                    E.Emp_LastName = Console.ReadLine();
                                    Console.WriteLine("Enter the Employee Address : ");
                                    E.Emp_Address = Console.ReadLine();
                                    Console.WriteLine("Enter the Date of Birth : ");
                                    E.Emp_DOB = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Date of Joining : ");
                                    E.Emp_DOJ = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter Qualification : ");
                                    E.Emp_Qua = Console.ReadLine();

                                    obj_pms.UpdateEmployee(E);
                                    break;
                                case 4:
                                    obj_pms.ShowEmployee();
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("----------- Department Maintenance -----------");
                            Console.WriteLine("1) Add New Department");
                            Console.WriteLine("2) Delete Existing Department");
                            Console.WriteLine("3) Update Existing Department Details");
                            Console.WriteLine("4) Fetch Department Details");
                            Console.WriteLine("Enter your choice:");
                            int Deptchoice = Convert.ToInt32(Console.ReadLine());

                            switch (Deptchoice)
                            {
                                case 1:

                                    Console.WriteLine("Enter the Deprtment ID : ");
                                    D.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Department Name : ");
                                    D.Dept_Name = Console.ReadLine();
                                    Console.WriteLine("Enter the Deprtment Location : ");
                                    D.Dept_Location = Console.ReadLine();
                                    Console.WriteLine("Enter the Departmnet Phone : ");
                                    D.Dept_Phone = Console.ReadLine();


                                    obj_pms.AddDepartment(D);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Department ID to Delete Details");
                                    string delDeptID = Console.ReadLine();
                                    obj_pms.DeleteDepartment(delDeptID);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Department ID to Update Details");
                                    D.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Department Name : ");
                                    D.Dept_Name = Console.ReadLine();
                                    Console.WriteLine("Enter the Deprtment Location : ");
                                    D.Dept_Location = Console.ReadLine();
                                    Console.WriteLine("Enter the Departmnet Phone : ");
                                    D.Dept_Phone = Console.ReadLine();
                                    string UpdDeptID = Console.ReadLine();
                                    obj_pms.UpdateDepartment(D);
                                    break;
                                case 4:
                                    obj_pms.ShowDepartment();
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("----------- Project Maintenance -----------");
                            Console.WriteLine("1) Add New Project");
                            Console.WriteLine("2) Delete Existing Project");
                            Console.WriteLine("3) Update Existing Project Details");
                            Console.WriteLine("4) Fetch Project Details");
                            Console.WriteLine("Enter your choice:");
                            int Projchoice = Convert.ToInt32(Console.ReadLine());

                            switch (Projchoice)
                            {
                                case 1:

                                    Console.WriteLine("Enter the Project ID : ");
                                    P.Proj_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Department ID : ");
                                    P.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Name : ");
                                    P.Proj_Name = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Budget : ");
                                    P.Proj_Budjet = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Start Date : ");
                                    P.Proj_Start_Date = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Project End Date : ");
                                    P.Proj_End_Date = Convert.ToDateTime(Console.ReadLine());


                                    obj_pms.AddProject(P);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Project ID to Delete Details");
                                    string delProjID = Console.ReadLine();
                                    obj_pms.DeleteProject(delProjID);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Project ID to Update Details");
                                    P.Proj_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Department ID : ");
                                    P.Dept_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Name : ");
                                    P.Proj_Name = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Budget : ");
                                    P.Proj_Budjet = Console.ReadLine();
                                    Console.WriteLine("Enter the Project Start Date : ");
                                    P.Proj_Start_Date = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Project End Date : ");
                                    P.Proj_End_Date = Convert.ToDateTime(Console.ReadLine());
                                    obj_pms.UpdateProject(P);
                                    break;
                                case 4:
                                    obj_pms.ShowProject();
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        case 4:
                            Console.WriteLine("----------- Work Maintenance -----------");
                            Console.WriteLine("1) Add New WorkDetails");
                            Console.WriteLine("2) Delete Existing WorkDetails");
                            Console.WriteLine("3) Update Existing WorkDetails");
                            Console.WriteLine("4) Fetch WorkDetails");
                            Console.WriteLine("Enter your choice:");
                            int Workchoice = Convert.ToInt32(Console.ReadLine());

                            switch (Workchoice)
                            {
                                case 1:

                                    Console.WriteLine("Enter the Employee ID : ");
                                    W.Emp_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Project ID : ");
                                    W.Proj_ID = Console.ReadLine();
                                    Console.WriteLine("Enter Work Hours : ");
                                    W.WorkHours = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter work Hours per week : ");
                                    W.WorkHours_per_Week = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Work Rate per hour : ");
                                    W.Work_Rate_per_hour = Console.ReadLine();
                                    Console.WriteLine("Enter the Work Assign Date : ");
                                    W.Work_Assign_Date = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Work Release Date : ");
                                    W.Work_Rel_Date = Convert.ToDateTime(Console.ReadLine());


                                    obj_pms.AddWorksOn(W);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter Employee ID to Delete Details");
                                    string delWorkID = Console.ReadLine();
                                    obj_pms.DeleteWorksOn(delWorkID);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Employee ID to Update Details");
                                    W.Emp_ID = Console.ReadLine();
                                    Console.WriteLine("Enter the Project ID : ");
                                    W.Proj_ID = Console.ReadLine();
                                    Console.WriteLine("Enter Work Hours : ");
                                    W.WorkHours = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter work Hours per week : ");
                                    W.WorkHours_per_Week = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Work Rate per hour : ");
                                    W.Work_Rate_per_hour = Console.ReadLine();
                                    Console.WriteLine("Enter the Work Assign Date : ");
                                    W.Work_Assign_Date = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Enter the Work Release Date : ");
                                    W.Work_Rel_Date = Convert.ToDateTime(Console.ReadLine());
                                    obj_pms.UpdateWorksOn(W);
                                    break;
                                case 4:
                                    obj_pms.ShowWorksOn();
                                    break;
                                default:
                                    Console.WriteLine("Wrong Choice");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;

                    }
                }
            }
        }
    }
}


