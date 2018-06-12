using System;
using System.Collections.Generic;

namespace ProviderService.data.models
{
    public partial class TbuProvider
    {
        public TbuProvider()
        {
            // TbuHospitalAffiliation = new HashSet<TbuHospitalAffiliation>();
            // TbuProviderSpecialty = new HashSet<TbuProviderSpecialty>();
        }

        public int PhysicianId { get; set; }
        public string Deanumber { get; set; }
        public string ProviderStatus { get; set; }
        public string ProviderType { get; set; }

        public virtual TbuPhysician Physician {get;set;}
        public virtual TbuFacility Facility {get;set;}
        // public ICollection<TbuHospitalAffiliation> TbuHospitalAffiliation { get; set; }
        // public ICollection<TbuProviderSpecialty> TbuProviderSpecialty { get; set; }
    }
}
