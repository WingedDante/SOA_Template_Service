using System.Collections.Generic;
using ToDoService.DAL.Models;
using ToDoService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoService.DAL.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService.DAL.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoContext _context;

        public ToDoRepository(ToDoContext toDoContext){
            _context = toDoContext;
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            // 
            return _context.ToDos;
        }

        public IEnumerable<ToDoItem> Search(string name)
        {

            return  _context.ToDos.Where(t => t.Title == name);

           

        }
        public async Task<int> Add(ToDoItem toDo){

            await _context.ToDos.AddAsync(toDo);
           return await _context.SaveChangesAsync();
        }
    }
}