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
            if (IsValid(uniqueName))
            {
                return new UniqueName(uniqueName);
            }
            else
            {
                throw new InvalidOperationException("Invalid UniqueName given.");
            }
        }
        public static bool IsValid(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_.-]+$"))
            {
                return false;
            }
            if (name.Length < 5 || name.Length > 30)
            {
                return false;
            }
            if (!char.IsLetter(name[0]))
            {
                return false;
            }
            return true;
        }
    }
}
