using AutoMapper;
using landscape_be.data;
using landscape_be.models;
using landscape_be.models.dto;
using Microsoft.EntityFrameworkCore;

namespace landscape_be.services
{
    public class EmployeeService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var entities = await _context.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(entities);
        }

        public async Task<EmployeeDto> AddAsync(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);
            entity.Id = 0; // if DB is identity
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(entity);
        }

    }
}
