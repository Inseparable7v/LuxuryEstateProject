namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class PropertyInputModel : BasePropertyInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
