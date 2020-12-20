namespace LuxuryEstateProject.Data.Models
{
    using System.Collections.Generic;

    using LuxuryEstateProject.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
