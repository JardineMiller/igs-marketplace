using System;

namespace marketplace.Data.Models.Base
{
    public interface IAuditEntity
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
    }

    public class AuditEntity : IAuditEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
