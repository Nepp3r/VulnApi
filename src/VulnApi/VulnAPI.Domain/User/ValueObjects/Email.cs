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
            if (IsValid(_value))
            {
                return new Email(_value);
            }
            else
            {
                throw new InvalidOperationException("Invalid Email given");
            }
        }

        public static bool IsValid(string email)
        {
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
