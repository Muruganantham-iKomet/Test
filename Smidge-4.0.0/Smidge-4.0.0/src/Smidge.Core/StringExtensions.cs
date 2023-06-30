﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Smidge
{

    public static class StringExtensions
    {

        internal static bool InvariantIgnoreCaseStartsWith(this string input, string value)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(input, value, CompareOptions.IgnoreCase);            
        }

        internal static string TrimExtension(this string input, string extension)
        {
            extension = extension.TrimStart('.');
            var li = input.LastIndexOf('.');
            if (li > 0)
            {
                input = input.Substring(0, li);
            }
            return input;
        }

        internal static string EnsureEndsWith(this string input, char endsWith)
        {
            var asString = endsWith.ToString();
            if (!input.EndsWith(asString))
            {
                return string.Concat(input, asString);
            }
            return input;
        }

        internal static string EnsureStartsWith(this string input, char startsWith)
        {
            var asString = startsWith.ToString();
            if (!input.StartsWith(asString))
            {
                return string.Concat(asString, input);
            }
            return input;
        }

        public static string ReplaceNonAlphanumericChars(this string input, char replacement)
        {
            //any character that is not alphanumeric, convert to a hyphen
            var mName = input;
            foreach (var c in mName.ToCharArray().Where(c => !char.IsLetterOrDigit(c)))
            {
                mName = mName.Replace(c, replacement);
            }
            return mName;
        }

        public static string ReverseString(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string EncodeTo64Url(this string toEncode)
        {
            string returnValue = EncodeTo64(toEncode);

            // returnValue is base64 = may contain a-z, A-Z, 0-9, +, /, and =.
            // the = at the end is just a filler, can remove
            // then convert the + and / to "base64url" equivalent
            //
            returnValue = returnValue.TrimEnd(new char[] { '=' });
            returnValue = returnValue.Replace("+", "-");
            returnValue = returnValue.Replace("/", "_");

            return returnValue;
        }

        public static string EncodeTo64(this string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        public static string DecodeFrom64Url(this string toDecode)
        {
            // see BaseFileRegistrationProvider.EncodeTo64Url
            //
            toDecode = toDecode.Replace("-", "+");
            toDecode = toDecode.Replace("_", "/");
            int rem = toDecode.Length % 4; // 0 (aligned), 1, 2 or 3 (not aligned)
            if (rem > 0)
                toDecode = toDecode.PadRight(toDecode.Length + 4 - rem, '='); // align

            return DecodeFrom64(toDecode);
        }

        public static string DecodeFrom64(this string toDecode)
        {
            byte[] toDecodeAsBytes = Convert.FromBase64String(toDecode);
            return Encoding.UTF8.GetString(toDecodeAsBytes);
        }

        /// <summary>
        /// checks if the string ends with one of the strings specified. This ignores case.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static bool EndsWithOneOf(this string str, string[] ext)
        {
            var upper = str.ToUpper();
            bool isExt = false;
            foreach (var e in ext)
            {
                if (upper.EndsWith(e.ToUpper()))
                {
                    isExt = true;
                    break;
                }
            }
            return isExt;
        }
    }
}