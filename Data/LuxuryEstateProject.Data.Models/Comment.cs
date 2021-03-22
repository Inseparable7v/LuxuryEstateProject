namespace LuxuryEstateProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LuxuryEstateProject.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int AgentId { get; set; }

        public virtual Agent Agent { get; set; }
    }
}
