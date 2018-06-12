using System;
using System.Collections.Generic;
using System.Linq;
using ProviderService.data.models;
using ProviderService.data;
using ProviderService.data.Repositories;
using ProviderService.data.Repositories.Interfaces;
using AutoMapper;
using ProviderService.data.ViewModels;
using ProviderService.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace ProviderService.Services
{
    using Interfaces;
    using ProviderService.BusinessLogic.Interfaces;

    /*
        Service is orchestrating your meat and potatoes, getting data from your repo,
        sending it to/through your BL to transform it, and using automapper to map the result to pass it back
        in a VM to the controller/(other service)
     */
    public class ProvidersService : IProviderService
    {
        private IProviderRepository _repository;
        private readonly IMapper _mapper;
        private IPhysicianProvider _physicianProvider;

        public ProvidersService(IProviderRepository repository, IMapper mapper, IPhysicianProvider physicianProvider ){
            _repository = repository;
            _mapper = mapper;
            _physicianProvider = physicianProvider;
        }

        public IEnumerable<ProviderVM> GetAllProviders(){
            //Get data
            var Provider_result = _repository.GetAll();
            
            //Transform Data With BL
            _physicianProvider.DoStuff();

            //Map and Return Data VM
            return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);
        }

        public IEnumerable<ProviderVM> GetProvider(string name){
            //Get data
            var Provider_result = _repository.Search(name);

            //Transform Data With BL
            _physicianProvider.DoStuff();

            //Map and Return Data VM
            return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);

        }


    }

}