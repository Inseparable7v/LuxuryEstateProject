namespace LuxuryEstateProject.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        /// <inheritdoc/>
        [Column("CreatedOn_19118027")]
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc/>
        [Column("ModifiedOn_19118027")]
        public DateTime? ModifiedOn { get; set; }
    }
}
