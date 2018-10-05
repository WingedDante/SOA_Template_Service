using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoService.DAL.Models;

namespace ToDoService.Services.Interfaces
{
    public interface IToDoService
    {
        IEnumerable<ToDoItem> GetAllToDoItems();
        IEnumerable<ToDoItem> GetToDoItem(string name);
        Task<int> AddToDoItem(ToDoItem item);
    }
}