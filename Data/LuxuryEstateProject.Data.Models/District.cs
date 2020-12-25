namespace LuxuryEstateProject.Data.Models
{

    using LuxuryEstateProject.Data.Common.Models;

    public class District : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
