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
            var UserId = HttpContext.User.Claims.Where(c 
                => c.Type == ClaimTypes.NameIdentifier).Select(c 
                => c.Value).FirstOrDefault();
            return Ok(await _todoTaskService.GetTodoTasksAsync(UserId, input));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
                var UserId = HttpContext.User.Claims.Where(c
                  => c.Type == ClaimTypes.NameIdentifier).Select(c
                  => c.Value).FirstOrDefault();
            var task = await _todoTaskService.GetTodoTasksAsync(UserId, id);
            if(task == null)
            {
                _logger.LogWarning("Task id not found");
                return NotFound(new ErrorResponse("Task id not found"));
            }
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TodoTaskResponseDTO>> PostTask(TodoTaskRequestDTO input)
        {
            var UserId = HttpContext.User.Claims.Where(c
                => c.Type == ClaimTypes.NameIdentifier).Select(c
                => c.Value).FirstOrDefault();
            var newTask = await _todoTaskService.AddTodoTaskAsync(UserId, input);
            if (newTask == null)
            {
                _logger.LogWarning("Cannot add new task");
                return BadRequest(new ErrorResponse("Cannot add new task"));
            }
            return Ok(newTask);
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<TodoTaskResponseDTO>> PutTask(int id, [FromBody] TodoTaskRequestByIdDTO input)
        {
            var UserId = HttpContext.User.Claims.Where(c
                => c.Type == ClaimTypes.NameIdentifier).Select(c
                => c.Value).FirstOrDefault();
            if (id != input.TaskId)
            {
                _logger.LogWarning("Task id not found");
                return NotFound(new ErrorResponse("Task id not found"));
            }
            var updateTask = await _todoTaskService.UpdateTodoTaskAsync(UserId, id, input);
            return Ok(updateTask);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteTask([FromRoute] int id, TodoTask model)
        {
            var UserId = HttpContext.User.Claims.Where(c
                => c.Type == ClaimTypes.NameIdentifier).Select(c
                => c.Value).FirstOrDefault();
            if (id != model.TaskId)
            {
                _logger.LogWarning("Task id not found");
                return NotFound(new ErrorResponse("Task id not found"));
            }
            await _todoTaskService.DeleteTodoTaskAsync(UserId, id);
            return Ok("Delete successfully");
        }
        [HttpPatch("tasks/complete")]
        public async Task<IActionResult> CompleteTask([FromBody] List<int> id)
        {
            var UserId = HttpContext.User.Claims.Where(c
                => c.Type == ClaimTypes.NameIdentifier).Select(c
                => c.Value).FirstOrDefault();
            await _todoTaskService.CompleteTaskAsync(UserId, id);
            return Ok("Task completed");
        }
    }
}
