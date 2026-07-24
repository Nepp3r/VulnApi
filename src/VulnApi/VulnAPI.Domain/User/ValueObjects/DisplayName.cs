using System;
using System.Text.RegularExpressions;

namespace VulnAPI.Domain.User.ValueObjects
{
    public record DisplayName
    {
        public string Value { get; }
        private DisplayName(string _value)
        {
            Value = _value;
        }
        public static DisplayName Create(string _value) {
            Validate(_value);
            _value = _value.Trim();
            return new DisplayName(_value);
        }
        public static void Validate(string displayName)
        {
            if (displayName is null)
                throw new ArgumentNullException("User name cannot be null", nameof(displayName));
            if (displayName.Length < 3 || displayName.Length > 30)
                throw new ArgumentException("User name has incorrect length", nameof(displayName));
            if (!Regex.IsMatch(displayName, @"^[a-zA-Z\s'-]+$"))
                throw new ArgumentException("User name contains invalid characters", nameof(displayName));
            return;
        }
    }
}
