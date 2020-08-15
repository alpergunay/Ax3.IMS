using System;

namespace Ax3.IMS.DataAccess.Mongo.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class ConnectionNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the CollectionName class attribute with the desired name.
        /// </summary>
        /// <param name="value">Name of the collection.</param>
        public ConnectionNameAttribute(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Empty connection name is not allowed", nameof(value));
            Name = value;
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>The name of the collection.</value>
        public virtual string Name { get; private set; }
    }
}
