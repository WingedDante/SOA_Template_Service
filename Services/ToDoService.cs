using System;
using System.Collections.Generic;
using System.Linq;
using ToDoService.DAL.Models;
using ToDoService.DAL;
using ToDoService.DAL.Repositories;
using ToDoService.DAL.Repositories.Interfaces;
using AutoMapper;
// using ToDoService.DAL.Models;
using ToDoService.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace ToDoService.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    // using ToDoService.BusinessLogic.Interfaces;

    /*
        Service is orchestrating your meat and potatoes, getting data from your repo,
        sending it to/through your BL to transform it, and using automapper to map the result to pass it back
        in a VM to the controller/(other service)
     */
    public class ToDoService : IToDoService
    {
        private IToDoRepository _repository;
        private readonly IMapper _mapper;
        // private IPhysicianProvider _physicianProvider;
                                                                                //Example BLL injection
        public ToDoService(IToDoRepository repository, IMapper mapper /* , IPhysicianProvider physicianProvider */ ){
            _repository = repository;
            _mapper = mapper;
            // _physicianProvider = physicianProvider;
        }

        public IEnumerable<ToDoItem> GetAllToDoItems(){
            //Get data
            var ToDo_result = _repository.GetAll();
            
            //Transform Data With BL
            // _physicianProvider.DoStuff();

            return ToDo_result;
            //Map and Return Data VM
            // return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);
        }

        public IEnumerable<ToDoItem> GetToDoItem(string name){
            //Get data
            var ToDo_result = _repository.Search(name);

            //Transform Data With BL
            // _physicianProvider.DoStuff();

            return ToDo_result;
            //Map and Return Data VM
            // return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);

        }

        public async Task<int> AddToDoItem(ToDoItem item)
        {
            var insert_result = await _repository.Add(item);

            return insert_result;
        }

        public async Task<int> DeleteToDoItem(int id){
            var delete_result = await _repository.Delete(id);
            return delete_result;
        }
        public ToDoItem GetToDoItemByID(int id){
            var ToDo_result =  _repository.GetToDo(id);
            return ToDo_result;
        }
    }

}