using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecurityApp.Domain.Common
{
    public abstract class BaseDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; } = string.Empty;

        protected BaseDomain()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
