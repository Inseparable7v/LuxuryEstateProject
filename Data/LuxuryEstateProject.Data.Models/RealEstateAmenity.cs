﻿namespace LuxuryEstateProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RealEstateAmenity
    {
        public int Id { get; set; }

        public int AmenityId { get; set; }

        public virtual Amenity Amenity { get; set; }

        public int RealEstatePropertyId { get; set; }

        public virtual RealEstateProperty RealEstateProperty { get; set; }
    }
}
