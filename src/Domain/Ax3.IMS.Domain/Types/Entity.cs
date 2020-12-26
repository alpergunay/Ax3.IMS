using Ax3.IMS.Infrastructure.Cache.Redis;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ax3.IMS.Domain.Types
{
    public class Entity : IEntity<Guid>
    {
        private DateTime _createdOn;
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public bool IsDeleted { get; set; }
        public string EntityCacheKey => GetEntityCacheKey(GetType(), Id);

        /// <summary>
        /// id in string format
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// create date
        /// </summary>

        public DateTime CreatedOn
        {
            get
            {
                if (_createdOn == null || _createdOn == DateTime.MinValue)
                    _createdOn = DateTime.UtcNow;
                return _createdOn;
            }
            set
            {
                _createdOn = value;
            }
        }

        /// <summary>
        /// modify date
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// id in objectId format
        /// </summary>

        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Entity(Guid id)
        {
            Id = id;
        }

        public Entity(Guid id, string creator)
        {
            Id = id;
            CreatedOn = DateTime.UtcNow;
            Creator = creator;
            SetUpdatedDate();
        }

        public static string GetEntityCacheKey(Type entityType, object id)
        {
            return string.Format(CachingDefaults.EntityCacheKey, entityType.Name.ToLower(), id);
        }

        protected virtual void SetUpdatedDate()
           => ModifiedOn = DateTime.UtcNow;

        public bool IsTransient()
        {
            return this.Id == default(Guid);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }

    /// <summary>
    /// Entity wrapper for non-edittable models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T> : Entity
    {
        /// <summary>
        /// Generic content
        /// </summary>
        public T Content { get; set; }
    }
}