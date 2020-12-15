namespace LuxuryEstateProject.Services.Data
{
    using System.Collections.Generic;

    public interface ICountryService 
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
