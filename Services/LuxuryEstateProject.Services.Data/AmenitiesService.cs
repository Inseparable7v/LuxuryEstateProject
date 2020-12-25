namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AmenitiesService : IAmenities
    {
        private IDeletableEntityRepository<Amenity> amenitiesRepository;

        public AmenitiesService(IDeletableEntityRepository<Amenity> amenitiesRepository)
        {
            this.amenitiesRepository = amenitiesRepository;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.amenitiesRepository.AllAsNoTracking().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }
    }
}
