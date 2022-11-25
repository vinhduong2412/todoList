using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.DTOs;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskRepo;

        public TasksController(ITaskService repo)
        {
            _taskRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlltodoTasks()
        {
            try
            {
                return Ok(await _taskRepo.GetAllTodoTasksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepo.GetTodoTasksAsync(id);
            return task == null? NotFound() : Ok(task);
        }    
        [HttpPost]
        
        public async Task<IActionResult> PostTask(todoTask input)
        {
            try
            {
                var newTaskId = await _taskRepo.AddTodoTaskAsync(input);
                
                return newTaskId == null ? NotFound() : Ok(newTaskId);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutTask(int id, [FromBody] todoTask input)
        {
            if (id != input.Id)
            {
                return NotFound();    
            }
            await _taskRepo.UpdateTodoTaskAsync(id, input);
            return Ok("Update successfully");
        }
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteBook([FromRoute] int id, todoTaskDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _taskRepo.DeleteTodoTaskAsync(id);
            return Ok("Delete successfully");
        }
    }
}
