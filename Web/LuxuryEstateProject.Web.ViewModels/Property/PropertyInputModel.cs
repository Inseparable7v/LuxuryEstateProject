namespace LuxuryEstateProject.Web.ViewModels.Property
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class PropertyInputModel : BasePropertyInputModel
    {
        public ICollection<IFormFile> Images { get; set; }
    }
}
