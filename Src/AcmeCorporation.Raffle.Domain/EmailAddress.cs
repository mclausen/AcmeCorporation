using System;
using System.Text.RegularExpressions;

namespace AcmeCorporation.Raffle.Domain
{
    public class EmailAddress
    {
        public string Value { get;  protected set; }


        private const string EmailValidationRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        public EmailAddress(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            ValidateEmail(value);
            Value = value;
        }

        private static void ValidateEmail(string value)
        {
            var regex = new Regex(EmailValidationRegex);

            var isValidEmail = regex.IsMatch(value);

            if (isValidEmail == false)
                throw new DomainException($"{value} is not a valid email");
        }
    }
}