using System;
using System.Collections.Generic;

namespace Ax3.IMS.Infrastructure.Configuration.SettingsImplementation
{
    public sealed class SettingsSection : IEquatable<SettingsSection>
    {
        public SettingsSection(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Settings = new List<Setting>();
        }

        public string Name { get; }

        public List<Setting> Settings { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is SettingsSection && Equals((SettingsSection)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name != null ? Name.GetHashCode() : 0) * 397;
            }
        }

        public bool Equals(SettingsSection other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name);
        }
    }
}