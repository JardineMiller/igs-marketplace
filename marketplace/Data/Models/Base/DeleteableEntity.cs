using System;

namespace marketplace.Data.Models.Base
{
    public interface IDeleteableEntity
    {
        DateTimeOffset? DeletedOn { get; set; }
        bool IsDeleted { get; set; }
    }
    public class DeleteableEntity : AuditEntity, IDeleteableEntity
    {
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
