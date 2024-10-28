using EjemploApplication.Models;

namespace EjemploApplication.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if (await _context.Employees.AnyAsync(e => e.RFC == employee.RFC))
                throw new ArgumentException("Employee with this RFC already exists.");

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync(string? name = null)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.Name.Contains(name) || e.LastName.Contains(name));

            return await query.OrderBy(e => e.BornDate).ToListAsync();
        }
    }

}
