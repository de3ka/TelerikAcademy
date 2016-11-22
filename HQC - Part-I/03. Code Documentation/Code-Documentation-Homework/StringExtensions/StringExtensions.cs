﻿//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extensions commonly used as operations on strings.
    /// Has Several options: <br/>
    /// StringExtensions.<see cref="StringExtensions.ToBoolean"/>. <br/>
    /// StringExtensions.<see cref="StringExtensions.ToMd5Hash"/>. <br/>
    /// StringExtensions.<see cref="StringExtensions.ToShort"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToInteger"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToLong"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToDateTime"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.CapitalizeFirstLetter"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.GetStringBetween"/>  <br/>
    /// StringExtensions.<see cref="StringExtensions.ConvertCyrillicToLatinLetters"/>  <br/>
    /// StringExtensions.<see cref="StringExtensions.ConvertLatinToCyrillicKeyboard"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToValidUsername"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToValidLatinFileName"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.GetFirstCharacters"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.GetFileExtension"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToContentType"/> <br/>
    /// StringExtensions.<see cref="StringExtensions.ToByteArray"/>
    /// <code>Example:
    /// Console.WriteLine(StringExtensions.ToContentType("doc"));
    /// logs: "application/msword"
    /// </code>
    /// Can't make instance of this class. It's static
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Hash algorithm called "MD5" <a href="https://bg.wikipedia.org/wiki/MD5">More about MD5</a>. It is used to convert text to hexadecimal values.
        /// </summary>
        /// <param name="input">Text to convert.</param>
        /// <returns>Hexadecimal converted value from a text.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            
            return builder.ToString();
        }

        /// <summary>
        /// Checks if a string is true-like (true, ok, yes, 1, да).
        /// </summary>
        /// <param name="input">Text to check.</param>
        /// <returns>True or false.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts string to a short type value (-32767 to 32767).
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <returns>Short type value. If parameter is incorrect returns 0.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to an integer type value (-2147483647 to 2147483647).
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <returns>Integer type value. If parameter is incorrect returns 0.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to a long type value (-9223372036854775807 to 9223372036854775807).
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <returns>Long type value. If parameter is incorrect returns 0.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts string to a DateTime type value.
        /// </summary>
        /// <param name="input">Type string with template: "dd/MM/yyyy hh:mm:ss".
        /// Depends on system settings.</param>
        /// <returns>DateTime type value. If parameter is incorrect returns: 01/01/0001 00:00:00.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts the first letter of a text to upper case.
        /// </summary>
        /// <param name="input">A text of type String</param>
        /// <returns>Capitalized text. If the string is null or empty ("") returns an empty string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gets text between two strings.
        /// </summary>
        /// <param name="input">String text to export.</param>
        /// <param name="startString">Start string</param>
        /// <param name="endString">End string</param>
        /// <param name="startFrom">Optional: start index.</param>
        /// <returns>Text between two strings. If the start or the end string are not found returns empty string.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters to their appropriate representation of latin. Works with both lower and upper case letters.
        /// </summary>
        /// <param name="input">Text to convert.</param>
        /// <returns>Text that contains only latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin letters to their appropriate representation in cyrillic. 
        /// Based on Bulgarian Phonetic Traditional typewriting.
        /// Works with both lower and upper case letters.
        /// </summary>
        /// <param name="input">Text to convert.</param>
        /// <returns>Text that contains only cyrillic letters (Bulgarian).</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Validates a text to be used as username. Allowed characters: all letters (cyrillic and latin), digits, underline and dot. 
        /// </summary>
        /// <param name="input">Username as text.</param>
        /// <returns>Valid username without spaces with latin letters.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Validates filename. Replaces all spaces with dashes. Allowed characters: latin letters, digits, underline, dot and dash.
        /// </summary>
        /// <param name="input">Filename as text.</param>
        /// <returns>Valid filename text.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Retrieves first <i>n</i> characters from a current instance.  
        /// </summary>
        /// <param name="input">Text to operate on.</param>
        /// <param name="charsCount">A positive number - number of characters.</param>
        /// <returns>Returns first <i>n</i> characters. If <code>charCount</code> is bigger than the current instance length returns the whole text.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            charsCount = (charsCount < 0) ? 0 : charsCount;
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Validates file extension.
        /// </summary>
        /// <param name="fileName">Filename as text.</param>
        /// <returns>File extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return "." + fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the file extension and returns it's type.
        /// </summary>
        /// <param name="fileExtension">File extension without the dot.</param>
        /// <returns>The type of the file extension. If it's included returns "application/octet-stream".</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Makes a byte array from a text with offset "0" and char code of symbols.
        /// </summary>
        /// <param name="input">Text to work with.</param>
        /// <returns>Byte array that contains char symbols from a text, separated with a zero offset.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}