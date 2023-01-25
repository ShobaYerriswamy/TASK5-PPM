using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;  
using System.IO;
using MODEL;
using Domain;

namespace UserInterface
{
    public class Viewing
    {
        public void View()
        {
            ProjectManager PM =  new ProjectManager();
            EmployeeManager EM = new EmployeeManager();
            RoleManager RM = new RoleManager();
            Project project = new Project();
            Employee employee = new Employee();
            Role role = new Role();
            RM.roleList.Add(new Role(1, "Software Engineer"));
            RM.roleList.Add(new Role(2, "Associate Software Engineer"));
            RM.roleList.Add(new Role(3, "Trainee Software Engineer"));
            RM.roleList.Add(new Role(4, "Technical Lead"));

            Boolean error = false;

            Regex phonenumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            View:

                Console.WriteLine("");
                Console.WriteLine(" ***** HELLO PROLIFICS EMPLOYEE ***** ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 1 to View Project Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 2 to View Employee Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 3 to View Role Module");
                Console.WriteLine("");
                Console.WriteLine(" Enter 4 to Save State");
                Console.WriteLine("");
                Console.WriteLine(" Enter 'S' to QUIT the Application ");
                Console.WriteLine("");

                var UserInput = Console.ReadLine();

                while (true)
                {
                    repeat:

                    switch (UserInput)
                    {
                        case "1":
                            while (true)
                            {
                                projectModule:

                                Console.WriteLine(" ***** PROJECT MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Project ");
                                Console.WriteLine(" Enter 2 to List All projects ");
                                Console.WriteLine(" Enter 3 to List Project By Id ");
                                Console.WriteLine(" Enter 4 to List Project By Name ");
                                Console.WriteLine(" Enter 5 to Adding Employee to Project ");
                                Console.WriteLine(" Enter 6 to Remove Employee from Project ");
                                Console.WriteLine(" Enter 7 to View Projects with Employees by Project ID ");
                                Console.WriteLine(" Enter 8 to Delete Project ");
                                Console.WriteLine(" Enter 9 to View Projects with Employees ");
                                Console.WriteLine(" Enter \"x\" to Exit to Main Menu ");
                                Console.WriteLine("");

                                var projectSelector =  Console.ReadLine();

                                switch(projectSelector)
                                {
                                    case "1":
                                        
                                        do
                                        {
                                            try
                                            {
                                                inputprojectid:

                                                    error = false;
                                                    Console.WriteLine("Enter the Project ID");
                                                    int projectid = Convert.ToInt32(Console.ReadLine());
                                                    for (int i=0; i<PM.projectList.Count; i++)
                                                    {
                                                        if (PM.projectList[i].id == projectid)
                                                        {
                                                            Console.WriteLine("This ID already exists try new ID");
                                                            Console.WriteLine("Enter any key to Try Again");
                                                            Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                            string idTry = Console.ReadLine();

                                                            if (idTry == "x")
                                                            {
                                                                goto projectModule;
                                                            }
                                                            else
                                                            {   
                                                                goto inputprojectid;
                                                            }
                                                        }
                                                    }
                                
                                                    Console.WriteLine("Enter the Name of Project");
                                                    string name = Console.ReadLine();
                                
                                                StartDate:

                                                    Console.WriteLine("Enter the Start Date of Project DD/MM/YYYY format");
                                                
                                                    string start = Console.ReadLine();
                                
                                                    if(!date.IsMatch(start))
                                                    {
                                                        Console.WriteLine("Invalid Date Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                        var sDateread=Console.ReadLine();

                                                        if(sDateread == "x")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            goto StartDate;
                                                        }
                                                    }
                                
                                                EndDate:

                                                    Console.WriteLine("Enter End Date of Project in DD/MM/YYYY format");
                                                
                                                    string end = Console.ReadLine();
                                                
                                                    if (!date.IsMatch(end))
                                                    {
                                                        Console.WriteLine("Invalid Date Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter \"x\" to Exit to Main Menu");
                                    
                                                        var eDateread = Console.ReadLine();
                                    
                                                        if (eDateread == "x")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {   
                                                            goto EndDate;
                                                        }
                                                    }

                                                    Project project1 = new Project(name, start, end, projectid);
                                                    PM.AddingProjects(project1);
                                                    project = project1;
                                                    Console.WriteLine("Added Successfully");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Would You Like To Add Employees to this Project?");
                                                    Console.WriteLine("Enter \"Yes\" to Add or Enter Anything to Deny");
                                                
                                                    var addEmployeeOrNot = Console.ReadLine();

                                                    if (addEmployeeOrNot == "Yes")
                                                    {
                                                        EM.ShowEmployees();
                                                        Console.WriteLine("Above are the Available Employees");
                                                        Console.WriteLine("Enter the ID of Employee to Add into Project");
                                                        int employeeIdSelect = Convert.ToInt32(Console.ReadLine());
                                                    
                                                        if(EM.Exist(employeeIdSelect))
                                                        {
                                                            employee = EM.EmployeeDetails(employeeIdSelect);
                                                            PM.AddingEmployeeToProject(projectid,employee);
                                                            Console.WriteLine("Added Successfully");
                                                        }
                                                        
                                                        else 
                                                        {
                                                            Console.WriteLine("Employee Does Not Exist");
                                                        }
                                                    }

                                                    Console.WriteLine("Enter any key to get Main Menu");
                                                    Console.ReadLine();
                                            }

                                            catch(FormatException e)
                                            {
                                                Console.WriteLine("\nError : only use Numbers for ID");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                                                UserInput= Console.ReadLine();
                                            
                                                if(UserInput == "x")
                                                {
                                                    break;
                                                }
                                                error = true;
                                            }
                        
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("\nError : Only use Numbers for ID");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                                                UserInput = Console.ReadLine();
                                
                                                if(UserInput == "x")
                                                {
                                                    break;
                                                }
                                                error = true;
                                            }
                                        }

                                        while(error);
                                        break;
                        
                                    case "2":
                                        
                                        PM.DisplayAllProjects();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        
                                        try
                                        {
                                            Console.WriteLine("Serach Via Project ID");
                                            Console.WriteLine("Enter the ID of Project");
                                            int eid = Convert.ToInt32(Console.ReadLine());
                                            PM.ShowProject(eid);
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }

                                        catch(Exception e)
                                        {
                                            Console.WriteLine("ID can be only in Numbers");
                                        }
                                        break;

                                    case "4":
                                    
                                        Console.WriteLine("Type to Search for Project");
                                        UserInput = Console.ReadLine();
                                        PM.SearchProjectByName(UserInput);
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "5":
                                    
                                        try
                                        {
                                            PM.DisplayAllProjects();
                                            Console.WriteLine("Above are the Available Projects");
                                            EM.ShowEmployees();
                                            Console.WriteLine("Above are the Available Employees");
                                            Console.WriteLine("Enter the Project ID for which you want to add Employees");

                                            int PROJId =Convert.ToInt32(Console.ReadLine());
                        
                                            if(PM.Exist(PROJId))
                                            {
                                                Console.WriteLine("Enter the ID of Employee to Add Into Project");
                                                int employeeIdSelecting = Convert.ToInt32(Console.ReadLine());
                        
                                                if(EM.Exist(employeeIdSelecting))
                                                {
                                                    Employee employeeSelect = EM.EmployeeDetails(employeeIdSelecting);
                                                    if(!PM.IfExistsInEmployee(employeeIdSelecting, PROJId))
                                                    {
                                                        PM.AddingEmployeeToProject(PROJId,employeeSelect);
                                                        Console.WriteLine("Added Successfully");
                                                    }
                                                    
                                                    else
                                                    {
                                                        Console.WriteLine("Employee already Exist in this Project");
                                                    }
                                                }
                                                
                                                else
                                                {
                                                    Console.WriteLine("Employee Does Not Exist");
                                                }
                                            }
                                            
                                            else
                                            {
                                                Console.WriteLine("Project Does Not Exist");
                                            }
                                        }                                   
                    
                                        catch(Exception e)
                                        {
                                            Console.WriteLine("Invalid Entry");
                                        }

                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "6":
                                        
                                        try
                                        {
                                            Console.WriteLine("Enter the Project ID for which you want to Delete Employees");

                                            int PROJId1 =Convert.ToInt32(Console.ReadLine());
                        
                                            if(PM.Exist(PROJId1))
                                            {
                                                Console.WriteLine("Enter the ID of Employee to Delete from Project");
                                                int EmpId1 = Convert.ToInt32(Console.ReadLine());
                        
                                                if(PM.IfExistsInEmployee(EmpId1))
                                                {
                                                    employee = EM.EmployeeDetails(EmpId1);
                                                    PM.EmployeeFromProject(PROJId1,employee);
                                                    Console.WriteLine("Successfully Deleted");
                                                }
                                                
                                                else
                                                {
                                                    Console.WriteLine("No Employee Present in this Project with this ID");
                                                }
                                            }
                                            
                                            else
                                            {
                                                Console.WriteLine("Project Does Not Exist");
                                            }
                                        }
                                    
                                        catch(FormatException e)
                                        {
                                            Console.WriteLine("ID can only in Integer");
                                        }

                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "7":
                                    
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Project");
                                            int readForId = Convert.ToInt32(Console.ReadLine());
                                            
                                            if(PM.Exist(readForId))
                                            {
                                                PM.DisplayEmployeesInProjectById(readForId);
                                                Console.WriteLine(" ------------------------------------------- ");
                                            }
                                            
                                            else
                                            {
                                                Console.WriteLine("No Project Present with this ID");
                                            }
                                        }
                                        
                                        catch(FormatException e)
                                        {
                                            Console.WriteLine("ID can only in Number");
                                        }
                                    
                                        catch(Exception e)
                                        {
                                            Console.WriteLine("ID can only in Integer");
                                        }

                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "8":
                                    
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Project to Delete");
                                            int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                            if (PM.Exist(idforDeleting))
                                            {
                                                for (int i=0; i<PM.projectList.Count; i++)
                                                {
                                                    for (int j=0; j<PM.projectList[i].EmployeeListfromEmployeeManager.Count; j++)
                                                    {
                                                        if (PM.projectList[i].id == idforDeleting)
                                                        {
                                                            PM.EmployeeFromProject(idforDeleting, PM.projectList[i].EmployeeListfromEmployeeManager[j]);
                                                        }
                                                    }
                                                
                                                    if (PM.projectList[i].id == idforDeleting)
                                                    {
                                                        PM.DeleteProject(idforDeleting, PM.projectList[i]);
                                                        Console.WriteLine("Successfully Deleted");
                                                    }
                                                }
                                            }
                                        
                                            else
                                            {
                                                Console.WriteLine("No Project Exists with this ID");
                                            }
                                        }
                                    
                                        catch(FormatException e)
                                        {
                                            Console.WriteLine("ID can only in Number");
                                        }
                                    
                                        catch(Exception e)
                                        {
                                            Console.WriteLine("ID can only in Number");
                                        }

                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;
                                
                                    case "9":
                                        PM.Display();
                                        Console.WriteLine("Enter any key to get Main menu");
                                        Console.ReadLine();
                                        break;

                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input, Provide Correct Input");
                                        break;
                                }
                            }
                    
                        case "2":

                            while(true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(" ***** EMPLOYEE MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Employee ");
                                Console.WriteLine(" Enter 2 to List All Employees ");
                                Console.WriteLine(" Enter 3 to List Employee By Id ");
                                Console.WriteLine(" Enter 4 to Delete Employee ");
                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                Console.WriteLine("");

                                var employeeSelector = Console.ReadLine();
                                switch(employeeSelector)
                                {
                                    case "1":
                                    
                                        tryagain:
                                        
                                            try
                                            {
                                                inputempid:

                                                    Console.WriteLine("Enter the ID of Employee");
                                                    int empId = Convert.ToInt32(Console.ReadLine());
                                                    for(int i =0; i<EM.employeeList.Count; i++)
                                                    {
                                                        if (empId == EM.employeeList[i].employeeID)
                                                        {
                                                            Console.WriteLine("The ID already exists try new ID");
                                                            Console.WriteLine("Enter any key to Try Again");
                                                            Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                        
                                                            string empidTry = Console.ReadLine();

                                                            if (empidTry == "x") 
                                                            {
                                                                goto tryagain;
                                                            }       
                                                        
                                                            else
                                                            {
                                                                goto inputempid;
                                                            }
                                                        }
                                                    }

                                                    Console.WriteLine("Enter Employee Fist Name");
                                                    var fname = Console.ReadLine();
                                                    Console.WriteLine("Enter Employee Last Name");
                                                    var lname = Console.ReadLine();

                                                Email:

                                                    Console.WriteLine("Enter Employee Email ID");
                                                
                                                    var EMAIL= Console.ReadLine();
                                                
                                                    if(!email.IsMatch(EMAIL))
                                                    {
                                                        Console.WriteLine("Invalid Email Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                
                                                        var emailread=Console.ReadLine();

                                                        if(emailread=="x")
                                                        {
                                                            break;
                                                        }
                                                    
                                                        else
                                                        {
                                                            goto Email;
                                                        }
                                                    }

                                                mobile:

                                                    Console.WriteLine("Enter Employee Mobile Number");
                                                
                                                    var mobile = Console.ReadLine();
                                                
                                                    if(!phonenumber.IsMatch(mobile))
                                                    {
                                                        Console.WriteLine("Invalid Mobile Number format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                    
                                                        var mobileread=Console.ReadLine();

                                                        if(mobileread=="x")
                                                        {
                                                            break;
                                                        }
                                                        
                                                        else
                                                        {
                                                            goto mobile;
                                                        }
                                                    }
                            
                                                    Console.WriteLine("Enter Employee Address");
                            
                                                    var address = Console.ReadLine();

                                                Option:

                                                    Console.WriteLine("Select 1 for Assinging Employee with New Role Name and New Role ID");
                                                    Console.WriteLine("Select 2 for Assinging Existing Role to the Employee");
                            
                                                    int selection = Convert.ToInt32(Console.ReadLine());

                                                    if(selection == 1)
                                                    {
                                                        try
                                                        {
                                                            roleID:
                                                                Console.WriteLine("Enter the Role ID");
                                                                int roleID = Convert.ToInt32(Console.ReadLine());

                                                                if (RM.Exist(roleID))
                                                                {
                                                                    Console.WriteLine("Role with this ID already Exists");
                                                                    Console.WriteLine("Enter any key to Try Again");
                                                                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");

                                                                    var tryagain = Console.ReadLine();

                                                                    if (tryagain == "x")
                                                                    {
                                                                        break;
                                                                    }
                                                                
                                                                    else
                                                                    {
                                                                        goto roleID;
                                                                    }
                                                                }
                                                            
                                                                else
                                                                {
                                                                    Console.WriteLine("Enter the Name of Role");
                                                                    string rolename = Console.ReadLine();
                                                                    Console.WriteLine(rolename); 
                                                                
                                                                    Role role1 = new Role(roleID, rolename);
                                                                    RM.RoleAdd(role1);

                                                                    Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, roleID,  rolename);
                                                                    EM.AddEmployee(employee1);
                                                                    employee = employee1;
                                                                    Console.WriteLine("Added Successfully");
                                                                }
                                                        }

                                                        catch(Exception e)
                                                        {
                                                            Console.WriteLine("Role ID should be in Numbers only");
                                                        }
                                                    }

                                                    else if (selection == 2)
                                                    {
                                                        try
                                                        {
                                                            Selectrole:

                                                                RM.ViewRole();
                                                                Console.WriteLine("Select Role ID from Above List to assign Role to Employee");
                                                                int role1 = Convert.ToInt32(Console.ReadLine());
                                                                string? roleNAME1 = null;

                                                                if(RM.Exist(role1))
                                                                {
                                                                    for (int i=0; i<RM.roleList.Count; i++)
                                                                    {
                                                                        if (RM.roleList[i].roleId == role1)
                                                                        {
                                                                            roleNAME1 = RM.roleList[i].roleName;
                                                                        }
                                                                    }
                                                                }
                                                            
                                                                else
                                                                {
                                                                    Console.WriteLine("Role Does Not Exist");
                                                                    Console.WriteLine("Enter any key to Try Again");
                                                                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");

                                                                    string tryemprole = Console.ReadLine();

                                                                    if (tryemprole == "x")
                                                                    {
                                                                        goto repeat;
                                                                    }
                                                                
                                                                    else
                                                                    {
                                                                        goto Selectrole;
                                                                    }
                                                                }
                                                        
                                                                Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, role1, roleNAME1);
                                                                EM.AddEmployee(employee1);
                                                                employee = employee1;
                                                                Console.WriteLine("Added Successfully!");
                                                        }
                                
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine("Employee ID should be in Numbers only");
                                                        }
                                                    }
                            
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid entry");
                                                        Console.WriteLine("Try Again");
                                                        goto Option;
                                                    }
                                            }

                                            catch(FormatException e)
                                            {
                                                Console.WriteLine("ID can only be in Numbers");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");

                                                string EmpIdTry = Console.ReadLine();

                                                if(EmpIdTry == "x")
                                                {
                                                    goto breaking;
                                                }

                                                else
                                                {
                                                    goto tryagain;
                                                }
                                            }

                                            catch(Exception e)
                                            {
                                                Console.WriteLine("Invalid Entry");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                                                string EmpIdTry1 = Console.ReadLine();

                                                if(EmpIdTry1 == "x")
                                                {
                                                    goto breaking;
                                                }

                                                else
                                                {
                                                    goto tryagain;
                                                }
                                            }
                            
                                            Console.WriteLine("Enter any key to get to Main Menu");
                                            Console.ReadLine();
                                            breaking:
                                            break;
                    
                                    case "2":
                                        EM.ShowEmployees();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int searchEmployeeById = Convert.ToInt32(Console.ReadLine());
                                            EM.ShowEmployee(searchEmployeeById);
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }

                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("ID can only be in Numbers");
                                        }
                                    
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        break;

                                    case "4":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                            for (int i=0; i< EM.employeeList.Count; i++)
                                            {
                                                if (EM.employeeList[i].employeeID == idforDeleting)
                                                {
                                                    for (int j=0; j<PM.projectList.Count; j++)
                                                    {
                                                        if (PM.projectList.Count !=0 && PM.projectList[j].EmployeeListfromEmployeeManager.Count !=0)
                                                        {
                                                            for (int k=0; k<PM.projectList[j].EmployeeListfromEmployeeManager.Count; k++)
                                                            {
                                                                if (PM.projectList[j].EmployeeListfromEmployeeManager[k].employeeID == idforDeleting)
                                                                {
                                                                    PM.projectList[j].EmployeeListfromEmployeeManager.Remove(PM.projectList[j].EmployeeListfromEmployeeManager[k]);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    EM.DeleteEmployee(idforDeleting, EM.employeeList[i]);
                                                    Console.WriteLine("Deleted Successfully");
                                                }
                                            }
                                            
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                            break;
                                        }
                                    
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("Enter Valid Input");
                                        }
                                        break;
                                
                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input, Provide Correct Input");
                                        break;
                                }
                            }

                        case "3":

                            while(true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(" ***** ROLE MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Role ");
                                Console.WriteLine(" Enter 2 to List All Roles ");
                                Console.WriteLine(" Enter 3 to List Roles By Id ");
                                Console.WriteLine(" Enter 4 to Delete Role ");
                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                Console.WriteLine("");

                                var roleSelector = Console.ReadLine();
                                switch (roleSelector)
                                {
                                    case "1":
                                        try
                                        {
                                            inputroleid:

                                                Console.WriteLine("Enter the Role Id");
                                                int roleIDD = Convert.ToInt32(Console.ReadLine());
                                                for(int i = 0; i<RM.roleList.Count; i++)
                                                {
                                                    if(roleIDD == RM.roleList[i].roleId)
                                                    {
                                                        Console.WriteLine("The ID already exists try new ID");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                   
                                                        string roleidTry = Console.ReadLine();

                                                        if (roleidTry == "x") 
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            goto inputroleid;
                                                        }
                                                    }
                                                }

                                                Console.WriteLine("Enter the Name of Role");
                                                string role_name = Console.ReadLine();
                                                Role newRole = new Role(roleIDD, role_name);
                                                RM.RoleAdd(newRole);
                                                Console.WriteLine("Added Successfully!");

                                                Console.WriteLine("Enter any key to get Main Menu");
                                                Console.ReadLine();
                                        }   
                        
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Role ID should be in Numbers only");
                                            Console.ReadLine();
                                        }
                                        break;


                                    case "2":
                                        RM.ViewRole();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Role");
                                            int searchRoleById = Convert.ToInt32(Console.ReadLine());
                                            if (RM.Exist(searchRoleById))
                                            {
                                                RM.ListRoleById(searchRoleById);
                                            }
                                        
                                            else
                                            {
                                                Console.WriteLine("ID Does Not Exists");
                                            }
                                        
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }
                                    
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("ID should be in Numbers only");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        break; 

                                    case "4":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Role");
                                            int deleteRoleById = Convert.ToInt32(Console.ReadLine());
                                            if (RM.Exist(deleteRoleById))
                                            {
                                                if (EM.IfExistsByRole(deleteRoleById))
                                                {
                                                    Console.WriteLine("Looks like Employee consists this Role ID, Delete Employee with this Role Id First");
                                                }
                                                else
                                                {
                                                    RM.DeleteRole(deleteRoleById);
                                                    Console.WriteLine("Deleted Successfully");
                                                }
                                            }
                                            
                                            else
                                            {
                                                Console.WriteLine("ID Does Not Exists");
                                            }
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }
                                    
                                        catch ( FormatException e)
                                        {
                                            Console.WriteLine("ID should be in Numbers only");
                                        }
                                    
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        break;
                                
                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Entry");
                                        break;
                                }
                            }

                        case "4":

                            var serialiazerProject = new XmlSerializer(typeof(List<Project>));

                            var serialiazerEmployee = new XmlSerializer(typeof(List<Employee>));

                            var serializerRole = new XmlSerializer(typeof(List<Role>));

                            using (var writer = new StreamWriter (@"C:\Users\SMandlole\XmlSerialization file\Text.txt"))

                            {
                                serialiazerProject.Serialize(writer, PM.projectList);

                                serialiazerEmployee.Serialize(writer, EM.employeeList);

                                serializerRole.Serialize(writer, RM.roleList);
                            }

                            break;

                        case "S":
                            return;  
                    }

                Console.WriteLine("");
                Console.WriteLine(" ***** HELLO PROLIFICS EMPLOYEE ***** ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 1 to View Project Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 2 to View Employee Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 3 to View Role Module");
                Console.WriteLine("");
                Console.WriteLine(" Enter 4 to Save State");
                Console.WriteLine("");
                Console.WriteLine(" Enter 'S' to QUIT the Application ");
                Console.WriteLine("");
                UserInput = Console.ReadLine();

                }
        }
    }
}







                            

                    
                    
                    
                        
                    
               