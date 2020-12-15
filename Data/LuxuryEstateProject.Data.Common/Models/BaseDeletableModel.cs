namespace LuxuryEstateProject.Data.Common.Models
{
    using System;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        /// <inheritdoc/>
        public bool IsDeleted { get; set; }

        /// <inheritdoc/>
        public DateTime? DeletedOn { get; set; }
    }
}
