namespace LuxuryEstateProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Models;

    public class Amenities : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
