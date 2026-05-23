using landscape_be.data;
using landscape_be.models;
using Microsoft.EntityFrameworkCore;

namespace landscape_be.services
{
    public class EmployeeService
    {

        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

    }
}
