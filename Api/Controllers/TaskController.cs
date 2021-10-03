
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using System.Collections.Generic;
using Core.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
	    //private TaskDataAccessLayer _taskRepo = new TaskDataAccessLayer();

	    private readonly ITaskDataAccessLayer _taskRepo;

	    public TaskController(ITaskDataAccessLayer taskRepo)
	    {
			_taskRepo = taskRepo;
	    }

        [HttpGet]
        // GET
        public IEnumerable<Task> GetTasks()
        {
            return  _taskRepo.GetAllEmployees();
        }
        

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
	        _taskRepo.AddEmployee(task);
	        return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTask(Task task)
        {
	        _taskRepo.UpdateEmployee(task);
	        return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTask(string id)
        {
	        _taskRepo.DeleteEmployee(id);
	        return Ok();
        }
    }
}