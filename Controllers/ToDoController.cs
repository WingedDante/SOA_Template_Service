using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoService.DAL.Models;
using ToDoService.DAL;
using ToDoService.Services;

namespace ToDoService.Controllers
{
    /*
        Your Controllers really only care about handling the HTTP requests, 
        and getting information back from your services to respond with. 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        
        private ToDoService.Services.ToDoService _toDoService;
       
        public ToDoController(ToDoService.Services.ToDoService toDoService )
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> Get()
        {
            /*
                get data with _service
                apply _BL
                Return VM
             */
            var toDos = _toDoService.GetAllToDoItems();

            if (toDos != null)
            {
                return Ok(toDos);
            }
            else if (toDos.Count() == 0)
            {
                return Ok(toDos);
            }
            else
            {
                return Ok(new List<ToDoItem>());
            }


        }

        // POST api/toDos
        [HttpPost]
        public ActionResult<IEnumerable<ToDoItem>> Post([FromBody] string name)
        {
            if (name != null && name != "")
            {
                var toDos = _toDoService.GetToDoItem(name);

                if (toDos != null)
                {
                    return Ok(toDos);
                }
                else if (toDos.Count() == 0)
                {
                    return Ok(toDos);
                }
                else
                {
                    return Ok(new List<ToDoItem>());
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}