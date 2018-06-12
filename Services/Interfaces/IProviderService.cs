using System.Collections.Generic;
using ProviderService.data.ViewModels;

namespace ProviderService.Services.Interfaces
{
    public interface IProviderService
    {
        IEnumerable<ProviderVM> GetAllProviders();
        IEnumerable<ProviderVM> GetProvider(string name);

    }
}