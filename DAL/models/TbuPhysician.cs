using System;
using System.Collections.Generic;

namespace ProviderService.data.models
{
    public partial class TbuPhysician
    {
        public int PhysicianId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string ProviderCredential { get; set; }
        public string Gender { get; set; }
        public string Npi { get; set; }

        public virtual TbuProvider Provider {get;set;}
    }
}
