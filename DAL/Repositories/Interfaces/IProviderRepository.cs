using System.Collections.Generic;
using ProviderService.data.models;

namespace ProviderService.data.Repositories.Interfaces
{
    public interface IProviderRepository
    {
         IEnumerable<TbuProvider> GetAll();
         IEnumerable<TbuProvider> Search(string name);
    }
}