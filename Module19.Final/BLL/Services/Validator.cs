using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.BLL.Services
{
    public static class Validator
    {
        /// <summary>
        /// Static method for checking validity of email address
        /// </summary>
        /// <param name="address">Email address for validation</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ValidateAddress(string address)
        {
            if (!new EmailAddressAttribute().IsValid(address))
                throw new ArgumentNullException("Email", "Email address must contains a correct value!");
        }

        /// <summary>
        /// Static method for strings checking, Is it NullOrEmpty
        /// </summary>
        /// <param name="checkingString">Validation string</param>
        /// <param name="parameterName">Name of checking string for exception message</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ValidateString(string checkingString, string parameterName)
        {
            if (string.IsNullOrEmpty(checkingString))
                throw new ArgumentNullException(parameterName, "Parameter must contains non-empty value!");
        }

        /// <summary>
        /// Static method for strings checking, includes check for MAXimal string length
        /// </summary>
        /// <param name="checkingString">Validation string</param>
        /// <param name="parameterName">Name of checking string for exception message</param>
        /// <param name="maxLength">Maximal length of string</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateStringMaxSize(string checkingString, string parameterName, int maxLength)
        {
            ValidateString(checkingString, parameterName);
            if (checkingString.Length > maxLength)
                throw new ArgumentOutOfRangeException(parameterName, $"Parameter is too long (more than {maxLength} symbols)");
        }

        /// <summary>
        /// Static method for strings checking, includes check for MINimal string length
        /// </summary>
        /// <param name="checkingString">Validation string</param>
        /// <param name="parameterName">Name of checking string for exception message</param>
        /// <param name="minLength">Minimal length of string</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateStringMinSize(string checkingString, string parameterName, int minLength)
        {
            ValidateString(checkingString, parameterName);
            if (checkingString.Length < minLength)
                throw new ArgumentOutOfRangeException(parameterName, $"Parameter is too short (less than {minLength} symbols)");
        }
    }
}
