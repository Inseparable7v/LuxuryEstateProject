namespace LuxuryEstateProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LuxuryEstateProject.Data.Common.Repositories;
    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class DistrictService : IDistrict
    {
        private IDeletableEntityRepository<District> districtRepository;

        public DistrictService(IDeletableEntityRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {

            return this.districtRepository.AllAsNoTracking().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(c => c.Text);
        }

        public IEnumerable<SelectListItem> GetDistricts(int id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                List<SelectListItem> districts = this.districtRepository.AllAsNoTracking()
                    .OrderBy(n => n.Name)
                    .Where(n => n.City.Id == id)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name,
                        }).ToList();
                var districtFirstItem = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select district ---",
                };
                districts.Insert(0, districtFirstItem);

                return new SelectList(districts, "Value", "Text");
            }

            return null;
        }
    }
}
