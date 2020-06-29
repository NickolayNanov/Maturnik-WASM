using System;

namespace Maturnik.Domain.Common
{
    public abstract class BaseEntity<TKey> 
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public TKey Id { get; protected set; }

        public DateTime CreatedAt { get; }
    }
}
