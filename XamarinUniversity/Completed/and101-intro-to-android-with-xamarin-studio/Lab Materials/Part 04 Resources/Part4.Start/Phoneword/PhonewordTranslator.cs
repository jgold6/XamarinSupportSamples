﻿using System.Text;
using System;

namespace Core
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string alphanumericNumber)
        {
			if (string.IsNullOrWhiteSpace(alphanumericNumber))
                return string.Empty;

			var newNumber = new StringBuilder();
            foreach (var c in alphanumericNumber.ToUpperInvariant())
            {
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);
                else {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                }    
                // otherwise we've skipped a non-numeric char
            }

            return newNumber.ToString();
        }

		static bool Contains (this string keyString, char c)
		{
			return keyString.IndexOf(c) >= 0;
		}

        static int? TranslateToNumber(char c)
        {
            if ("ABC".Contains(c))
                return 2;
            else if ("DEF".Contains(c))
                return 3;
            else if ("GHI".Contains(c))
                return 4;
            else if ("JKL".Contains(c))
                return 5;
            else if ("MNO".Contains(c))
                return 6;
            else if ("PQRS".Contains(c))
                return 7;
            else if ("TUV".Contains(c))
                return 8;
            else if ("WXYZ".Contains(c))
                return 9;
            return null;
        }
    }
}