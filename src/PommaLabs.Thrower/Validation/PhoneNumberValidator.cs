// Taken from: http://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/PhoneAttribute.cs

using System.Text.RegularExpressions;

namespace PommaLabs.Thrower.Validation
{
    /// <summary>
    ///   A phone number validator.
    /// </summary>
    /// <remarks>A phone number validator.</remarks>
    public static class PhoneNumberValidator
    {
        private static readonly Regex PhoneNumberRegex = CreatePhoneNumberRegex();

        /// <summary>
        ///   Validates the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">A phone number.</param>
        /// <returns><c>true</c> if the phone number is valid; otherwise <c>false</c>.</returns>
        public static bool Validate(string phoneNumber)
        {
            // Preconditions
            Raise.ArgumentException.IfIsNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));

            return PhoneNumberRegex.IsMatch(phoneNumber);
        }

        private static Regex CreatePhoneNumberRegex()
        {
            const string pattern = @"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\/\.]?\d+)?\)|\d+)([\s\-\/\.]?(\(\d+([\s\-\/\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$";
#if (PORTABLE || NETSTD10)
            const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
#else
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
#endif
            return new Regex(pattern, options);
        }
    }
}