using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo.Data;
using todo.Models;
using todo.Repositories;

namespace todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepo _taskRepo;
        private object _mapper;

        public TasksController(ITaskRepo repo)
        {
            _taskRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlltodoTasks()
        {
            try
            {
                return Ok(await _taskRepo.GetAlltodoTasksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepo.GettodoTasksAsync(id);
            return task == null? NotFound() : Ok(task);
        }    
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTask(todoTaskModel model)
        {
            try
            {
                var newTaskId = await _taskRepo.AddtodoTaskAsync(model);
                var task = await _taskRepo.GettodoTasksAsync(newTaskId);
                return task == null ? NotFound() : Ok(task);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTask(int id, [FromBody] todoTaskModel model)
        {
            if (id != model.Id)
            {
                return NotFound();    
            }
            await _taskRepo.UpdatetodoTaskAsync(id, model);
            return Ok("Update successfully");
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook([FromRoute] int id, todoTaskModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _taskRepo.DeletetodoTaskAsync(id);
            return Ok("Delete successfully");
        }
    }
}
