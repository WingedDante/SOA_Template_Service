using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoService.DAL.Models;

namespace ToDoService.DAL.Repositories.Interfaces
{
    public interface IToDoRepository
    {
         IEnumerable<ToDoItem> GetAll();
         IEnumerable<ToDoItem> Search(string name);
         Task<int> Add(ToDoItem toDo);
    }
}