using System;

namespace Ordering.Domain.Common
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public Guid Id { get; protected set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

    }
}
