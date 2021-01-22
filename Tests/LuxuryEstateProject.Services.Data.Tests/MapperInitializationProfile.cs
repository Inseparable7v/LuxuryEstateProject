namespace LuxuryEstateProject.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using LuxuryEstateProject.Services.Mapping;

    public class MapperInitializationProfile
    {
        public MapperInitializationProfile()
        {
            AutoMapperConfig.RegisterMappings(Assembly.GetCallingAssembly());
        }
    }
}
