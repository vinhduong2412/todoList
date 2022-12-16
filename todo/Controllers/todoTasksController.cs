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
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TodoTasksController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
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
            return task == null ? BadRequest() : Ok(task);
        }
        [HttpPost]

        public async Task<ActionResult<TodoTaskResponseDTO>> PostTask(TodoTaskRequestDTO input)
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

        public async Task<ActionResult<TodoTaskResponseDTO>> PutTask(int id, [FromBody] TodoTaskRequestByIdDTO input)
        {
            if (id != input.TaskId)
            {
                return BadRequest();
            }
            var updateTask = await _todoTaskService.UpdateTodoTaskAsync(id, input);
            return Ok(updateTask);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBook([FromRoute] int id, TodoTask model)
        {
            if (id != model.TaskId)
            {
                return NotFound(new ErrorResponse("Invalid Task id"));
            }
            await _todoTaskService.DeleteTodoTaskAsync(id);
            return Ok("Delete successfully");
        }
        [HttpGet("Status")]
        public async Task<IActionResult> GetByStatus(bool Status)
        {
            var Task = await _todoTaskService.GetTasksByStatusAsync(Status);
            return Task == null ? BadRequest() : Ok(Task);
        }
        [HttpGet("Date")]
        public async Task<IActionResult> GetByDate(DateTime Date)
        {
            var Task = await _todoTaskService.GetTasksByDateAsync(Date);
            return Task == null ? BadRequest() : Ok(Task);
        }
        [HttpPatch("tasks/complete")]
        public async Task<IActionResult> CompleteTask([FromBody] List<int> id)
        {
            await _todoTaskService.CompleteTaskAsync(id);
            return Ok("Task completed");
        }
    }
}
