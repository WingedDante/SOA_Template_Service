using System.Collections.Generic;
using ToDoService.DAL.Models;
using ToDoService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoService.DAL.Contexts;
using System.Linq;

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
    }
}