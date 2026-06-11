using System;
using System.Text.RegularExpressions;

namespace VulnAPI.Domain.User.ValueObjects
{
    public record Name
    {
        public string Value { get; }
        private Name(string _value)
        {
            Value = _value;
        }
        public static Name Create(string _value) {
            Validate(_value);
            _value = _value.Trim();
            return new Name(_value);
        }
        public static void Validate(string name)
        {
            if (name == null)
                throw new ArgumentNullException("User name cannot be null", nameof(name));
            if (name.Length < 3 || name.Length > 30)
                throw new ArgumentException("User name has incorrect length", nameof(name));
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s'-]+$"))
                throw new ArgumentException("User name contains invalid characters", nameof(name));
            return;
        }
    }
}
