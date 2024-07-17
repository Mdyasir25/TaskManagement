using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Entities;
using TaskManagement.WebAPI.DTO;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/tasks")]
    public class TaskWorkController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<TaskWork>>> GetTaskWorks()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{taskworkid}")]
        public async Task<ActionResult> GetTaskWorkById(int taskWorkId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaskWork(TaskWorkCreationDTO taskCreationDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{taskworkid}")]
        public async Task<ActionResult> CompleteTaskWork(int taskWorkId, TaskWorkCompletionDTO taskWorkCompleteDTO)
        {
            throw new NotSupportedException();
        }

        [HttpPost]
        [Route("{taskworkid}/note")]
        public async Task<ActionResult> CreateNote(int taskWorkId, NoteCreationDTO noteCreationDTO, IFormFile? file = null)
        {
            throw new NotImplementedException();
        }

    }
}
