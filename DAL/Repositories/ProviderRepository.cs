using System.Collections.Generic;
using ProviderService.data.models;
using ProviderService.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProviderService.data.contexts;
using System.Linq;

namespace ProviderService.data.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private ProviderContext _context;

        public ProviderRepository(ProviderContext providerContext){
            _context = providerContext;
        }

        public IEnumerable<TbuProvider> GetAll()
        {
            return  _context.TbuProvider
                .Include(p => p.Physician)
                .Include(p => p.Facility)
                .AsEnumerable()
                .ToList();
        }

        public IEnumerable<TbuProvider> Search(string name)
        {

            return _context.TbuProvider
                    .Include(p => p.Physician)
                    .Include(p => p.Facility)
                    .Where(p => p.Facility.FacilityName.Contains(name)|| (p.Physician.FirstName + " " + p.Physician.MiddleName + " " + p.Physician.LastName).Contains(name))
                    .AsEnumerable()
                    .ToList();

           

        }
    }
}