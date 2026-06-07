using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VulnAPI.Domain.User.ValueObjects
{
    public record UniqueName
    {
        public string Value { get; }
        private UniqueName(string uniquename)
        {
            Value = uniquename;
        }
        public static UniqueName Create(string uniqueName)
        {
            Validate(uniqueName);
            return new UniqueName(uniqueName);
        }
        public static void Validate(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_.-]+$"))
            {
                throw new ArgumentException("Invalid format of user's uniqueName", nameof(name));
            }
            if (name.Length < 5 || name.Length > 30)
            {
                throw new ArgumentException("Invalid uniqueName length", nameof(name));
            }
            if (!char.IsLetter(name[0]))
            {
                throw new ArgumentException("First letter of uniqueName has to be a letter", nameof(name));
            }
        }
    }
}
