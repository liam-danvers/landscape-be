using landscape_be.models;
using landscape_be.models.dto;
using landscape_be.services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace landscape_be.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getAccount")]
        public async Task<ActionResult<EmployeeDto>> GetAccount(string name)
        {
            var data = await _service.GetAccountAsync(name);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] EmployeeDto employeeDto)
            {
            var created = await _service.AddAsync(employeeDto);
            return CreatedAtAction(nameof(GetAccount), new { name = created.FirstName }, created);
        }
    }
}
