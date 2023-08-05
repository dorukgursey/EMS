using EMS.DataAccessLayer;
using EMS.Models;

namespace EMS.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EMSDbContext _EMSDbContext;
        public EmployeeRepo(EMSDbContext context)
        {
            _EMSDbContext = context;
        }
        public void AddEmployee(Employee employee)
        {
            _EMSDbContext.Employees.Add(employee);
            _EMSDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _EMSDbContext.Employees.Find(id);
            if (employee != null)
            {
                _EMSDbContext.Employees.Remove(employee);
                _EMSDbContext.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _EMSDbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _EMSDbContext.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _EMSDbContext.Employees.Update(employee);
            _EMSDbContext.SaveChanges();
        }
    }
}
