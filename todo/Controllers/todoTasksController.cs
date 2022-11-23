using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.Data;

namespace todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class todoTasksController : ControllerBase
    {
        private readonly DataAccessContext _context;

        public todoTasksController(DataAccessContext context)
        {
            _context = context;
        }

        // GET: api/todoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<todoTask>>> GettodoTasks()
        {
            return await _context.todoTasks!.ToListAsync();
        }

        // GET: api/todoTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<todoTask>> GettodoTask(int id)
        {
            var todoTask = await _context.todoTasks!.FindAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return todoTask;
        }

        // PUT: api/todoTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttodoTask(int id, [FromForm]todoTask todoTask)
        {
            if (id != todoTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!todoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/todoTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<todoTask>> PosttodoTask(todoTask todoTask)
        {
            _context.todoTasks!.Add(todoTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettodoTask", new { id = todoTask.Id }, todoTask);
        }

        // DELETE: api/todoTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetodoTask(int id)
        {
            var todoTask = await _context.todoTasks!.FindAsync(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            _context.todoTasks.Remove(todoTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool todoTaskExists(int id)
        {
            return _context.todoTasks!.Any(e => e.Id == id);
        }
    }
}
