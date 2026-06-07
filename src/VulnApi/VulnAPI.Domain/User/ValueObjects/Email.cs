using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace VulnAPI.Domain.User.ValueObjects
{
    public record Email
    {
        public string Value { get; }
        private Email(string _value)
        {
            Value = _value;
        }
        public static Email Create(string _value)
        {
            Validate(_value);
            return new Email(_value);
        }

        public static void Validate(string email)
        {
            try
            {
                _ = new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException("Invalid email given");
            }
        }
    }
}
