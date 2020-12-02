namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;

    using LuxuryEstateProject.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual IEnumerable<City> Cities { get; set; }
    }
}
