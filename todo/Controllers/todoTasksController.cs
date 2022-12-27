using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.DTOs;
using Todo.Services;
using System.Security.Claims;
using AutoMapper;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly ILogger<TodoTasksController> _logger;

        public TodoTasksController(ITodoTaskService todoTaskService, ILogger<TodoTasksController> logger)
        {
            _todoTaskService = todoTaskService;
            _logger = logger; 
        }
        [HttpGet]
        public async Task<IActionResult> GetTodoTasks([FromQuery] FilterRequestDTO input)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            return Ok(await _todoTaskService.GetTodoTasksAsync(userId, input));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            var task = await _todoTaskService.GetTodoTasksAsync(userId, id);
            if(task == null)
            {
                _logger.LogInformation("Task not found");
                return NotFound(new ErrorResponse("Task not found"));
            }
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TodoTaskResponseDTO>> PostTask(TodoTaskRequestDTO input)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            var newTask = await _todoTaskService.AddTodoTaskAsync(userId, input);
            if (newTask == null)
            {
                _logger.LogInformation("Cannot add new task");
                return BadRequest(new ErrorResponse("Cannot add new task"));
            }
            return Ok(newTask);
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<TodoTaskResponseDTO>> PutTask(int id, [FromBody] TodoTaskRequestByIdDTO input)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            if (id != input.TaskId)
            {
                _logger.LogInformation("Task id not found");
                return BadRequest(new ErrorResponse("Task id not found"));
            }
            var updateTask = await _todoTaskService.UpdateTodoTaskAsync(userId, id, input);
            if (updateTask == null)
            {
                _logger.LogInformation("Task not found");
                return NotFound(new ErrorResponse("Task not found"));
            }
            return Ok(updateTask);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<TodoTaskResponseDTO>> DeleteTask([FromRoute] int id, TodoTask input)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            var task = await _todoTaskService.GetTodoTasksAsync(userId, id);
            if (id != input.TaskId)
            {
                _logger.LogInformation("Task id not found");
                return BadRequest(new ErrorResponse("Task id not found"));
            }
            var deleteTask = await _todoTaskService.DeleteTodoTaskAsync(userId, id);
            if (deleteTask == null)
            {
                _logger.LogInformation("Task not found");
                return NotFound(new ErrorResponse("Task not found"));
            }
            return Ok(task);
        }
        [HttpPatch("tasks/complete")]
        public async Task<IActionResult> CompleteTask([FromBody] List<int> id)
        {
            var userId = Guid.Parse(HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault());
            await _todoTaskService.CompleteTaskAsync(userId, id);
            return Ok("Task completed");
        }
    }
}
