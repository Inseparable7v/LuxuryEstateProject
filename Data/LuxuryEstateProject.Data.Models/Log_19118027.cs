using LuxuryEstateProject.Data.Common.Models;
using System;

namespace LuxuryEstateProject.Data.Models
{
    public class Log_19118027 : BaseDeletableModel<string>
    {
        public Log_19118027()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string OperationType { get; set; }

        public DateTime TimeOfTheChange { get; set; }
    }
}
