using MODEL;

namespace IEntityOperation
{
    public interface IEntityOperationProject
    {
         void AddingProjects(Project project);
         void ViewProject(Project project);
         void DisplayAllProjects();

         List<Employee> SearchingForEmployee (int readingProjectId);
         
         void DisplayEmployeesInProjectById(int readingProjectId);
         void AddingEmployeeToProject (int pid, Employee ename);
         void DeleteProject(int pid, Project project);
         void EmployeeFromProject(int pid, Employee ename);
         void ShowProject(int eid);
         void SearchProjectByName(string search);
    }

    public interface IEntityOperationEmployee
    {
        void AddEmployee(Employee employee);
        void ViewEmployee(Employee employee);
        void ShowEmployees();
        void ShowEmployee(int eid);
        void DeleteEmployee(int employeeId, Employee employee);
    }

    public interface IEntityOperationRole
    {
         void RoleAdd(Role role);
         void ViewRole();
         void ListRoleById(int roleId);
         void DeleteRole (int roleId);
    }
}
