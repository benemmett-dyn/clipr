﻿using System;
using System.Text.RegularExpressions;

namespace clipr.Core
{
    internal static class ArgumentValidation
    {
        public static bool IsAllowedShortName(char c)
        {
            return Char.IsLetter(c);
        }

        internal const string IsAllowedShortNameExplanation =
            "Short named arguments must be letters.";

        public static bool IsAllowedLongName(string name)
        {
            return name != null &&
                Regex.IsMatch(name, @"^[a-zA-Z][a-zA-Z0-9\-_]*[a-zA-Z0-9]$");
        }

        internal const string IsAllowedLongNameExplanation =
            "Long named arguments must begin with a letter, contain a letter, " +
            "digit, underscore, or hyphen, and end with a letter or a digit.";
    }
}
