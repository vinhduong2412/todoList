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
    public class todoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public todoTasksController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoTasks()
        {
            try
            {
                return Ok(await _todoTaskService.GetAllTodoTasksAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _todoTaskService.GetTodoTasksAsync(id);
            return task == null? BadRequest() : Ok(task);
        }    
        [HttpPost]
        
        public async Task<IActionResult> PostTask(todoTask input)
        {
            try
            {
                var newTaskId = await _todoTaskService.AddTodoTaskAsync(input);
                
                return newTaskId == null ? BadRequest() : Ok(newTaskId);
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
                return BadRequest();    
            }
            var updateTask = await _todoTaskService.UpdateTodoTaskAsync(id,input);
            return Ok(updateTask);
        }
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteBook([FromRoute] int id, todoTaskDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _todoTaskService.DeleteTodoTaskAsync(id);
            return Ok("Delete successfully");
        }
    }
}
