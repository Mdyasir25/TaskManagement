using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Entities;
using TaskManagement.WebAPI.DTO;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult> SignIn([FromBody] SignInDTO signInDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{employeeid}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{employeeid}/tasks")]
        public async Task<ActionResult<IReadOnlyCollection<TaskWork>>> GetTasks(int managerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{managerid}/subordinates")]
        public async Task<ActionResult<IReadOnlyCollection<Employee>>> GetSubordinates(int managerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{managerid}/subordinates/tasks")]
        public async Task<ActionResult<IReadOnlyCollection<TaskWork>>> GetSubordinatesTasks(int managerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{employeeid}/manager")]
        public async Task<ActionResult> GetManager(int employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{employeeid}/manager")]
        public async Task<ActionResult> PromoteToManager(int employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{employeeid}/manager/{manegerid}")]
        public async Task<ActionResult> SetManager(int employeeId, int manegerId)
        {
            throw new NotImplementedException();
        }
    }
}
