using Microsoft.AspNetCore.Mvc;
using MiniAPI.Models;
using MiniAPI.Repository;

namespace MiniAPI.Controllers
{
    [ApiController]
    [Route("tasks")] 
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> GetAll() {
            var tasks = TaskRepository.GetAllTasks()
                                      .Select(t => new TaskDTO(t));
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDTO> GetById(int id) {
            var task = TaskRepository.GetTask(id);
            if (task == null)
                return NotFound();

            return Ok(new TaskDTO(task));
        }

        [HttpPost]
        public ActionResult<TaskDTO> Create(TaskModel model) {
            var created = TaskRepository.CreateTask(model);
            var dto = new TaskDTO(created);

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public ActionResult<TaskDTO> Update(int id, TaskModel model) {
            var updated = TaskRepository.UpdateTask(id, model);
            if (updated == null)
                return NotFound();

            return Ok(new TaskDTO(updated));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var deleted = TaskRepository.DeleteTask(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
