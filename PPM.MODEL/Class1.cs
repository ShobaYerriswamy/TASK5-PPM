using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;  
using System.IO;  
using myAliasName2 = System.Collections.Generic.List<int>; 

namespace MODEL
{
    [Serializable]
    public class Project : IComparable<Project> 
    {
        [XmlArray("AvailableEmployees")]
        [XmlArrayItem("Employee")]
        public List<Employee> EmployeeListfromEmployeeManager { get; set; } = new List<Employee>();

        public string projectName {get; set;} = default!;
        public string startDate {get; set;} = default!;
        public string endDate {get; set;} = default!;
        public int id {get; set;} = default!;

        [XmlIgnore]        
        public int employeeId;

        public Project (string projectname, string startdate, string enddate, int Id )
        {
            this.projectName = projectname;
            this.startDate = startdate;
            this.endDate = enddate;
            this.id = Id;
        }

        public Project (int empid)
        {
            this.employeeId = empid;
        }
        public Project()
        {

        }

        public int CompareTo(Project other)
        {
            return this.id.CompareTo(other.id);
        }
    }

    [Serializable]
    public class Employee : IComparable<Employee>
    {
        public int employeeID {get; set;} = default!;

        public string employeefirstName{get;set;} = default!;
        public string lastName {get; set;} = default!;
        public string email {get; set;} = default!;
        public string mobile {get; set;} = default!;
        public string address {get; set;} = default!;
        public int roleId {get; set;} = default!;
        public string roleName { get; set; } = default!;

        public Employee(int employeeid, string FirstName, string LastName, string Email, string Mobile, string Address, int RoleID, string Rolename)
        {
            this.employeeID = employeeid;  
            this.employeefirstName = FirstName;
            this.lastName = LastName;
            this.email = Email;
            this.mobile = Mobile;
            this.address = Address;
            this.roleId = RoleID;
            this.roleName = Rolename;
        }

        public Employee()
        {

        }

        public int CompareTo(Employee other)
        {
            return this.roleId.CompareTo(other.roleId);
        }
    }

    [Serializable]
    public class Role : IComparable<Role>
    {
        public string? roleName {get; set;} 
        public int roleId {get; set;} = default!;

        public Role(int roleid, string roleName)
        {
            this.roleName = roleName;
            roleId = roleid;
        }

        public Role()
        {
            
        } 

        public int CompareTo(Role other)
        {
            return this.roleId.CompareTo(other.roleId);
        }  
    }
}