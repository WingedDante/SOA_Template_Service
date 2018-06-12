using System;
using System.Collections.Generic;

namespace ProviderService.data.models
{
    public partial class TbuFacility
    {
        public TbuFacility()
        {
            //TbuFacilityUrl = new HashSet<TbuFacilityUrl>();
        }

        public int PhysicianId { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Type { get; set; }

        //public ICollection<TbuFacilityUrl> TbuFacilityUrl { get; set; }
    }
}